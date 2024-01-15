using PrescriptionService.Configuration;
using PrescriptionService.Middlewares;

// Create a new WebApplicationBuilder for configuring the web application
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Load configuration settings from multiple configuration files, including environment-specific and Serilog configurations
builder.AddJsonConfigurationProvider(
    ("appsettings.json", false, true),
    ($"appsettings.{builder.Environment.EnvironmentName}.json", true, true),
    ("appsettings.serilog.json", false, true),
    ($"appsettings.serilog.{builder.Environment.EnvironmentName}.json", true, true)
);

// Register configuration services using Dependency Injection
builder.Services.AddConfiguration(builder.Configuration);

// Build the WebApplication
WebApplication app = builder.Build();

// Enable Cross-Origin Resource Sharing (CORS) to allow requests from any origin, method, and header
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

// Add custom exception handling middleware to gracefully handle exceptions
app.UseMiddleware<PrescriptionExceptionHandlerMiddleware>();

// Enable routing for handling HTTP requests
app.UseRouting();

// Enable Swagger/OpenAPI to document and visualize API endpoints
app.UseSwagger();
app.UseSwaggerUI();

// Enable authorization to handle authentication and authorization of requests
app.UseAuthorization();

// Map controllers to handle incoming HTTP requests
app.MapControllers();

// Run the application
app.Run();
