using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale;

public class SupplierServices
{
    private readonly WestWindContext _Context;
    internal SupplierServices(WestWindContext context)
    {
        _Context = context;
    }

    public List<Supplier> GetAllSuppliers()
    {
        return _Context.Suppliers.ToList();
    }
}
public class CategoryServices
{
    private readonly WestWindContext _Context;
    internal CategoryServices(WestWindContext context)
    {
        _Context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Category> GetAllCategories()
    {
        return _Context.Categories.ToList<Category>();
    }
}
