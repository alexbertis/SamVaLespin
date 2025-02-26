using Microsoft.AspNetCore.HttpLogging;
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

builder.Services.AddW3CLogging(logging =>
{
    // Log all W3C fields
    logging.LoggingFields = W3CLoggingFields.Date | W3CLoggingFields.Time | W3CLoggingFields.ConnectionInfoFields 
                            | W3CLoggingFields.TimeTaken | W3CLoggingFields.ProtocolStatus | W3CLoggingFields.Request;
    logging.AdditionalRequestHeaders.Add("X-Forwarded-For");

    logging.FileSizeLimit = 5 * 1024 * 1024;
    logging.RetainedFileCountLimit = 14;
    logging.FileName = "netapp";
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseW3CLogging();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpMetrics();

app.Run();
