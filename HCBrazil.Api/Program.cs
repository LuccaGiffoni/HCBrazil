using HCBrazil.Api.Common.Api;
using HCBrazil.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
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