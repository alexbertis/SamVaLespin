using Prometheus;
using SamVaLespin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ImageService>();

builder.Services.UseHttpClientMetrics();
builder.Services.AddMetricServer(options =>
{
    options.Port = 8091;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpMetrics();

app.Run();
