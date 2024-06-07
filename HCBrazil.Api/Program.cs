using HCBrazil.Api.Common.Api;
using HCBrazil.Api.Endpoints;
using HCBrazil.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddSettings();
builder.AddDocumentation();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddServices();

var app = builder.Build();
app.UseRouting();
if(app.Environment.IsDevelopment())
    app.ConfigureDevEnv();

app.UseCors(ApiSettings.CorsPolicyName);
app.MapEndpoints();

app.Run();