global using BookStore.Client.Services.GenreServices;
global using BookStore.Shared;
global using BookStore.Client.Services.BookServices;
global using BookStore.Client.Services.CustomerServices;
global using BookStore.Client.Services.SaleServices;
using BookStore.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISalesItemService, SaleItemService>();

// Register the telerik services
builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
