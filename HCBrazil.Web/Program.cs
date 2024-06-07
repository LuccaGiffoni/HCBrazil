using HCBrazil.Core;
using HCBrazil.Core.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HCBrazil.Web;
using HCBrazil.Web.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient(WebSettings.HttpClientName,
    options => { options.BaseAddress = new Uri(Settings.BackendUrl); });

builder.Services.AddTransient<IAttendeeService, AttendeeService>();
builder.Services.AddTransient<IViaCepService, ViaCepService>();

await builder.Build().RunAsync();
