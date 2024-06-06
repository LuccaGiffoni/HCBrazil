using System.Text;
using HCBrazil.Api.Data;
using HCBrazil.Api.Services;
using HCBrazil.Core;
using HCBrazil.Core.Models;
using HCBrazil.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
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