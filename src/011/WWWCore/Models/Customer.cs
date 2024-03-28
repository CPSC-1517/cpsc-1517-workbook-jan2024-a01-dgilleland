using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Index("CompanyName", Name = "CompanyName")]
[Index("AddressId", Name = "UX_Customers_AddressID", IsUnique = true)]
public partial class Customer
{
    [Key]
    [Column("CustomerID")]
    [StringLength(5)]
    public string CustomerId { get; set; } = null!;

    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(30)]
    public string ContactName { get; set; } = null!;

    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [StringLength(50)]
    public string ContactEmail { get; set; } = null!;

    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(24)]
    public string Phone { get; set; } = null!;

    [StringLength(24)]
    public string? Fax { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Customer")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
