using Microsoft.AspNetCore.Http.Features;
using netflix_clone_gateway.Yarp.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApiService();

builder.Services.Configure<FormOptions>(o =>
{
    o.MultipartBodyLengthLimit = long.MaxValue;
});

builder.WebHost.ConfigureKestrel(opts =>
{
    opts.Limits.MaxRequestBodySize = long.MaxValue;
});

var app = builder.Build();

app.ConfigureMiddleware();

app.MapGet("/", () => "Netflix Clone is running...");

app.Run();