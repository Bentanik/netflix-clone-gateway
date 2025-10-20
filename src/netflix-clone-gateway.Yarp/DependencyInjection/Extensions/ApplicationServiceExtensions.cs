using netflix_clone_gateway.Yarp.Common.Constants;

namespace netflix_clone_gateway.Yarp.DependencyInjection.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureApiService(this IHostApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection(ApiGatewayConstants.ReverseProxy));
    }
}
