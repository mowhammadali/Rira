using Products.App.Models.Entities;
using Products.App.Models.Enums;
using Products.App.Services.Interfaces;

namespace Products.App;

public class ProductsApp
{
    private readonly IProductService _productService;

    public ProductsApp(IProductService productService)
    {
        _productService = productService;
    }

    public void Run()
    {
        var queryByCategory = _productService.GetAllByCategory(Categories.Category1);
        PrintProductList(queryByCategory, nameof(queryByCategory));

        var queryBySortPrice = _productService.SortByPrice();
        PrintProductList(queryBySortPrice, nameof(queryBySortPrice));

        var totalPrice = _productService.GetTotalPrice();
        Console.WriteLine($"total price: {totalPrice}");

        var groupedByCategory = _productService.GroupByCategory();
        PrintGroupedByList(groupedByCategory, nameof(groupedByCategory));

        var averagePrice = _productService.GetAveragePrice();
        Console.WriteLine($"Average price: {averagePrice}");
    }

    private void PrintProductList(IEnumerable<Product> products, string title)
    {
        Console.WriteLine(title);

        foreach (var product in products)
        {
            Console.WriteLine(product.ToString());
        }
    }

    private void PrintGroupedByList(IEnumerable<IGrouping<Categories, Product>> groupedByCategory, string title)
    {
        Console.WriteLine(title);

        foreach (var group in groupedByCategory)
        {
            Console.WriteLine($"Group key: {group.Key}");

            foreach (var product in group)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}