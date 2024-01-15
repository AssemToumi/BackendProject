using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PrescriptionService.Configuration;
using PrescriptionService.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Load configuration settings
builder.AddJsonConfigurationProvider(
    ("appsettings.json", false, true),
    ($"appsettings.{builder.Environment.EnvironmentName}.json", true, true),
    ("appsettings.serilog.json", false, true),
    ($"appsettings.serilog.{builder.Environment.EnvironmentName}.json", true, true)
);

// Register configuration services
builder.Services.AddConfiguration(builder.Configuration);

WebApplication app = builder.Build();

// Enable Cross-Origin Resource Sharing (CORS)
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

// Add custom exception handling middleware
app.UseMiddleware<PrescriptionExceptionHandlerMiddleware>();

// Enable routing
app.UseRouting();

// Enable Swagger/OpenAPI
app.UseSwagger();
app.UseSwaggerUI();

// Enable authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
