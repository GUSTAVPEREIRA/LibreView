using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Api.Configurations;

public static class SwaggerConfiguration
{
    private const string Githublicense = "https://github.com/GUSTAVPEREIRA/LibreView/blob/main/LICENSE";
    private const string Github = "https://github.com/GUSTAVPEREIRA";

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "LibreView",
                    Version = "v1",
                    Description = "This project is a library manager",
                    Contact = new OpenApiContact
                    {
                        Email = "gugupereira123@hotmail.com",
                        Name = "Gustavo Antonio Pereira",
                        Url = new Uri(Github)
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri(Githublicense)
                    },
                    TermsOfService = new Uri(Githublicense)
                });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insert Token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            xmlPath = Path.Combine(AppContext.BaseDirectory, "Application.xml");
            c.IncludeXmlComments(xmlPath);

            xmlPath = Path.Combine(AppContext.BaseDirectory, "Core.xml");
            c.IncludeXmlComments(xmlPath);
        });

        services.AddFluentValidationRulesToSwagger();
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
        });
    }
}