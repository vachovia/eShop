using eShop.CoreBusiness.Services;
// using eShop.DataStore.HardCoded;
using eShop.DataStore.SQL.Dapper;
using eShop.ShoppingCart.LocalStorage;
using eShop.StateStore.LocalStorage;
using eShop.UseCases.OrderConfirmationScreen.Interfaces;
using eShop.UseCases.OrderConfirmationScreen;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.SearchProductScreen.Interfaces;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using eShop.UseCases.ViewProductScreen;
using eShop.UseCases.ViewProductScreen.Interfaces;
using eShop.UseCases.AdminPortal.OutstandingOrdersScreen;
using eShop.UseCases.AdminPortal.ProcessedOrderScreen.Interfaces;
using eShop.UseCases.AdminPortal.ProcessedOrderScreen;
using eShop.UseCases.AdminPortal.ProcessOrderScreen.Interfaces;
using eShop.UseCases.AdminPortal.ProcessOrderScreen;
using eShop.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces;
using eShop.DataStore.SQL.Dapper.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Added *****
builder.Services.AddAuthentication("eShop.CookieAuth").AddCookie("eShop.CookieAuth", config =>
{
    config.Cookie.Name = "eShop.CookieAuth";
    config.LoginPath = "/authenticate";
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IDataAccess>(cfg => new DataAccess(builder.Configuration.GetConnectionString("Default") ?? ""));
builder.Services.AddTransient<IProductRepository, ProductRepository>(); // Not in Memory any more to use AddSingleton
builder.Services.AddTransient<IOrderRepository, OrderRepository>(); // Not in Memory any more to use AddSingleton

builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

builder.Services.AddTransient<IViewOutstandingOrderUseCase, ViewOutstandingOrderUseCase>();
builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//Added! Should be after Routing ******
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Added for authorization *******
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
