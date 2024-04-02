using WestWindWholesale.DAL;
using WestWindWholesale.Models;
using Microsoft.EntityFrameworkCore; // for the .Include

namespace WestWindWholesale;

public class ProductServices
{
    private readonly WestWindContext _context;
    internal ProductServices(WestWindContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Product> GetProductsByCategoryId(int id)
    {
        return _context.Products
            .Include(p => p.Supplier)
            .Where(p => p.CategoryId == id)
            .ToList<Product>();
    }

    public List<Product> GetProducts()
    {
        return _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .ToList();
    }

    public List<Product> GetProductsByProductName(string partialName)
    {
        return _context.Products
            .Include(p => p.Supplier)
            .Include(p => p.Category)
            .Where(p => p.ProductName.Contains(partialName))
            .ToList();
    }

    public Product? GetProduct(int productId)
    {
        return _context.Products.Find(productId);
    }

    public int AddProduct(Product item)
    {
        _context.Products.Add(item);
        _context.SaveChanges();
        return item.ProductId;
    }

    public void UpdateProduct(Product item)
    {
        _context.Products.Update(item);
        _context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var found = _context.Products.Find(productId);
        if(found is not null)
        {
            _context.Products.Remove(found);
            _context.SaveChanges();
        }
    }
}
