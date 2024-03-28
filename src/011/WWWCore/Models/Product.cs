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

    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(20)]
    public string QuantityPerUnit { get; set; } = null!;

    public short? MinimumOrderQuantity { get; set; }

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

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
