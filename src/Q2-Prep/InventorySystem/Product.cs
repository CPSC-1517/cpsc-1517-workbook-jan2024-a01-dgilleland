using System.ComponentModel.DataAnnotations;

namespace InventorySystem;

public class Product
{
    #region Validation messages
    private const string INVALID_PRODUCT_VALUES = "Product construction violated validation requirements:";
    private const string INVALID_NAME = "Name is required";
    private const string INVALID_DESCRIPTION = "Description is required";
    private const string INVALID_RESTOCK_LEVEL = $"Restock levels must be between 1 and 1000 inclusive";
    private const string INVALID_RETURN_LEVEL = $"Return levels must be between 2 and 1000 inclusive";
    private const string INVALID_RETURN_RESTOCK_COMPARISON = "Return levels must be greater than restock levels";
    #endregion

    #region Properties
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = INVALID_NAME)]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = INVALID_DESCRIPTION)]
    public string Description { get; set; } = default!;

    [Range(1, 1000, ErrorMessage = INVALID_RESTOCK_LEVEL)]
    public int RestockLevel { get; set; }

    [Range(2, 1000, ErrorMessage = INVALID_RETURN_LEVEL)]
    public int ReturnLevel { get; set; }
    public bool IncludesStandardWarranty { get; set; } = true;
    #endregion

    #region Construction
    public Product()
    { }
    
    public Product(Guid id, string name, string description, int restockLevel = 10, int returnLevel = 25, bool includesWarranty = true)
    {
        var problems = RunValidation(name, description, restockLevel, returnLevel);
        if(problems.Any())
            throw new AggregateException(INVALID_PRODUCT_VALUES, problems);
        ProductId = id;
        Name = name.Trim();
        Description = description.Trim();
        RestockLevel = restockLevel;
        ReturnLevel = returnLevel;
        IncludesStandardWarranty = includesWarranty;
    }

    private IEnumerable<Exception> RunValidation(string name, string description, int restockLevel, int returnLevel)
    {
        if(string.IsNullOrWhiteSpace(name))
            yield return new ArgumentNullException(INVALID_NAME);
        if(string.IsNullOrWhiteSpace(description))
            yield return new ArgumentNullException(INVALID_DESCRIPTION);
        if(restockLevel < 1 || restockLevel > 1000)
            yield return new ArgumentOutOfRangeException(nameof(restockLevel), INVALID_RESTOCK_LEVEL);
        if(returnLevel < 2 || returnLevel > 1000)
            yield return new ArgumentOutOfRangeException(nameof(returnLevel), INVALID_RETURN_LEVEL);
        if(returnLevel < restockLevel)
            yield return new ArgumentException(INVALID_RETURN_RESTOCK_COMPARISON);
    }
    #endregion

    #region TSV Parse/ToString
    public override string ToString()
    {
        return $"{ProductId}\t{Name}\t{Description}\t{RestockLevel}\t{ReturnLevel}\t{IncludesStandardWarranty}";
    }
    public static Product Parse(string tsvText)
    {
        if(string.IsNullOrWhiteSpace(tsvText))
            throw new FormatException("Cannot format an empty string into a Product object");
        string[] parts = tsvText.Split('\t');
        if(parts.Length != 6)
            throw new FormatException($"Expected the TSV string to have 6 parts, but found {parts.Length}");
        return new Product(Guid.Parse(parts[0]), parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), bool.Parse(parts[5]));
    }
    #endregion
}
/*
class Product {
    }

    class InventoryItem {
        Guid SerialNumber
        Guid ProductId
        string Features
        Date DateOfManufacture
        InventoryItem()
        InventoryItem(SerialNumber, ProductId, ManufactuedOn, Features)
    }
*/