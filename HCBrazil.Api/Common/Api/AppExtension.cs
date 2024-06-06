namespace HCBrazil.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnv(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}