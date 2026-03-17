using Microsoft.OpenApi.Models;
using SocietySaaS.Infrastructure;
using MediatR;
using SocietySaaS.Application;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.API.Services;
using SocietySaaS.Application.Common.Behaviors;
using FluentValidation;
using SocietySaaS.Infrastructure.Persistence;
using SocietySaaS.API.Middleware;
using SocietySaaS.Infrastructure.Tenant;
using SocietySaaS.Infrastructure.Interceptors;
using SocietySaaS.Infrastructure.Persistence.Repositories;
using SocietySaaS.Infrastructure.Middleware;
using SocietySaaS.Application.Common.Authorization;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------
// Add Controllers
// -------------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();


// -------------------------------
// Swagger Configuration
// -------------------------------
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("TenantHeader", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-Tenant-Id",
        Type = SecuritySchemeType.ApiKey,
        Description = "Enter Tenant Id"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TenantHeader"
                }
            },
            Array.Empty<string>()
        }
    });
});


// -------------------------------
// Infrastructure Layer
// -------------------------------
builder.Services.AddInfrastructure(builder.Configuration);


// -------------------------------
// MediatR
// -------------------------------
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AppAssemblyReference).Assembly));


// -------------------------------
// Fluent Validation
// -------------------------------
builder.Services.AddValidatorsFromAssembly(typeof(AppAssemblyReference).Assembly);


// -------------------------------
// Application Services
// -------------------------------
builder.Services.AddScoped<ISocietyRepository, SocietyRepository>();
builder.Services.AddScoped<IUserContext, UserContext>();


// -------------------------------
// Pipeline Behavior (Validation)
// -------------------------------
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("society.create",
        policy => policy.Requirements.Add(
            new PermissionRequirement("society.create")));

    options.AddPolicy("society.update",
        policy => policy.Requirements.Add(
            new PermissionRequirement("society.update")));
});

// -------------------------------
// Build App
// -------------------------------
var app = builder.Build();


// -------------------------------
// Swagger
// -------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// -------------------------------
// Middleware Pipeline
// -------------------------------
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<TenantMiddleware>();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();