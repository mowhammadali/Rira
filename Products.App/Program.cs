using Microsoft.Extensions.DependencyInjection;
using Products.App;
using Products.App.Data;
using Products.App.Services;
using Products.App.Services.Interfaces;

// Hi my name is Mohammad Ali👋, This is a console application using dependency injection approach
// Packages: Microsoft.Extensions.DependencyInjection

IServiceCollection services = new ServiceCollection();

// Inject all dependencies
services.AddTransient<IProductService, ProductService>();
services.AddTransient<ProductData>();
services.AddTransient<ProductsApp>();

IServiceProvider serviceProvider = services.BuildServiceProvider();

// This is entry point of application
var app = serviceProvider.GetService<ProductsApp>();

app.Run();