using System.Reflection;
using HCBrazil.Api.Data;
using HCBrazil.Api.Services;
using HCBrazil.Core;
using HCBrazil.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HCBrazil.Api.Common.Api;

public static class BuildExtension
{
    public static void AddSettings(this WebApplicationBuilder builder)
    {
        ApiSettings.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Settings.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        Settings.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Highland Camps Brazil | API",
                Description = "The official API for HCBrazil solution developed by Lucca Giffoni",
                Contact = new OpenApiContact
                {
                    Name = "Lucca Giffoni",
                    Email = "luccagiffoni@novalens.tech",
                    Url = new Uri("https://github.com/LuccaGiffoni"),
                }
            });
            
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseMySql(ApiSettings.ConnectionString, ServerVersion.AutoDetect(ApiSettings.ConnectionString));
        });
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiSettings.CorsPolicyName,
                policy => policy.WithOrigins(
                    Settings.BackendUrl,
                    Settings.FrontendUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAttendeeService, AttendeeService>();
    }
}