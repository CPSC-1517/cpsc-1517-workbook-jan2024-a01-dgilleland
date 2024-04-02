using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Index("CategoryId", Name = "CategoriesProducts")]
[Index("CategoryId", Name = "CategoryID")]
[Index("ProductName", Name = "ProductName")]
[Index("SupplierId", Name = "SupplierID")]
[Index("SupplierId", Name = "SuppliersProducts")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Each product must be associated with a supplier")]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Each product must be categorized")]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(20)]
    public string QuantityPerUnit { get; set; } = null!;

    [Range(0, short.MaxValue, ErrorMessage = "Minimun Order Quantity cannot be negative")]
    public short? MinimumOrderQuantity { get; set; }

    [Column(TypeName = "money")]
    [Range(typeof(decimal), "0", "100000", ErrorMessage = "Units on Order cannot be negative")]
    public decimal UnitPrice { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Units on Order cannot be negative")]
    public int UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    public virtual Supplier Supplier { get; set; } = null!;
}
