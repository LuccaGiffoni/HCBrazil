using HCBrazil.Api.Common.Api;
using HCBrazil.Api.Endpoints;
using HCBrazil.Api.Data;
using Microsoft.EntityFrameworkCore;
using HCBrazil.Core.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
builder.AddSettings();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if(app.Environment.IsDevelopment())
    app.ConfigureDevEnv();

app.UseCors(ApiSettings.CorsPolicyName);
app.MapEndpoints();

app.Run();