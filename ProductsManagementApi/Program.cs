using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductsManagementApi.Services;
using ProductsManagementApi.Filters;
using System.Text.Json;
using System;
using ProductsManagementApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomActionFilter>();  // Register the custom action filter globally
});

// Add ProductService as a singleton
builder.Services.AddSingleton<ProductService>();

// Add services to the container for API documentation (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Enable CORS for development (adjust CORS policy as needed)
    app.UseCors(options =>
    {
        options.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error"); // Custom error handling page or endpoint
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Add your custom middleware for error handling
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();
app.Run();
