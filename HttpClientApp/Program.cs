using HttpClientApp;
using HttpClientApp.DataAccess;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// ApiHelper.InitializeClient();
//builder.Services.AddHttpClient("ProductRestClient", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7049/api/");
//    client.DefaultRequestHeaders.Clear();

//});
builder.Services.AddHttpClient<ProductClientService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7049/api/");
    client.DefaultRequestHeaders.Accept.Clear();
}).AddTransientHttpErrorPolicy(builder => builder.RetryAsync(3));

await builder.Build().RunAsync();
