using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Index("CompanyName", Name = "CompanyName")]
[Index("AddressId", Name = "UX_Suppliers_AddressID", IsUnique = true)]
public partial class Supplier
{
    [Key]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(30)]
    public string ContactName { get; set; } = null!;

    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(24)]
    public string Phone { get; set; } = null!;

    [StringLength(24)]
    public string? Fax { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Supplier")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
