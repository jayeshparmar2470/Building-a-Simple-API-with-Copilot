using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagementAPI.Middleware; // Ensure this line is present

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Copilot helped add the necessary services for controllers, API exploration, and Swagger documentation.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Copilot suggested adding Swagger for API documentation and HTTPS redirection for security.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Register middleware in the correct order.
// Copilot suggested the correct order for middleware: error handling, authentication, and logging.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.Run();