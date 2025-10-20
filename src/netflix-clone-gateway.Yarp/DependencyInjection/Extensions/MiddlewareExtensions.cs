namespace netflix_clone_gateway.Yarp.DependencyInjection.Extensions;

public static class MiddlewareExtensions
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment()) { }

        app.UseCors("AllowAll");

        app.MapReverseProxy();

        app.MapMethods("{**any}", new[] { "OPTIONS" }, context =>
        {
            context.Response.StatusCode = StatusCodes.Status204NoContent;
            return Task.CompletedTask;
        });
    }
}