using Products.App.Data;
using Products.App.Models.Entities;
using Products.App.Models.Enums;
using Products.App.Services.Interfaces;

namespace Products.App.Services;

public class ProductService : IProductService
{
    private readonly ProductData _productData;

    public ProductService(ProductData productData)
    {
        _productData = productData;
    }

    /// <summary> /// Retrieves all products belonging to the specified category. /// </summary>
    public List<Product> GetAllByCategory(Categories category)
    {
        var products = _productData.ProductList.Where(p => p.Category == category).ToList();

        return products;
    }

    /// <summary> /// Sorts all products by price in ascending or descending order. /// </summary>
    public List<Product> SortByPrice(SortDirection sortDirection)
    {
        var sortedProducts = sortDirection == SortDirection.Ascending
            ? _productData.ProductList.OrderBy(p => p.Price).ToList()
            : _productData.ProductList.OrderByDescending(p => p.Price).ToList();

        return sortedProducts;
    }

    /// <summary> /// Calculates and returns the total price of all products. /// </summary>
    public decimal GetTotalPrice()
    {
        var totalPrice = _productData.ProductList.Sum(p => p.Price);

        return totalPrice;
    }

    /// <summary> /// Groups products by their category. /// </summary>
    public IEnumerable<IGrouping<Categories, Product>> GroupByCategory()
    {
        var groupedByProducts = _productData.ProductList.GroupBy(p => p.Category);

        return groupedByProducts;
    }

    /// <summary> /// Calculates and returns the average price of all products. /// </summary>
    public decimal GetAveragePrice()
    {
        var sum = _productData.ProductList.Sum(p => p.Price);
        var averagePrice = sum / _productData.ProductList.Count;

        return averagePrice;
    }
}