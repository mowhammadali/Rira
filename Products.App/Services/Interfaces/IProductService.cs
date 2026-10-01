using Products.App.Data;
using Products.App.Models.Entities;
using Products.App.Models.Enums;

namespace Products.App.Services.Interfaces;

public interface IProductService
{
    List<Product> GetAllByCategory(Categories category);
    List<Product> SortByPrice(SortDirection sortDirection = SortDirection.Descending);
    decimal GetTotalPrice();
    IEnumerable<IGrouping<Categories, Product>> GroupByCategory();
    decimal GetAveragePrice();
}