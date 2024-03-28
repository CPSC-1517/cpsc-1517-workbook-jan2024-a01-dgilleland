using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Keyless]
public partial class InvoiceItem
{
    [StringLength(40)]
    public string? ShipName { get; set; }

    [StringLength(60)]
    public string ShipAddress { get; set; } = null!;

    [StringLength(15)]
    public string ShipCity { get; set; } = null!;

    [StringLength(15)]
    public string? ShipRegion { get; set; }

    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [StringLength(15)]
    public string ShipCountry { get; set; } = null!;

    [Column("CustomerID")]
    [StringLength(5)]
    public string CustomerId { get; set; } = null!;

    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(60)]
    public string Address { get; set; } = null!;

    [StringLength(15)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(15)]
    public string Country { get; set; } = null!;

    [StringLength(31)]
    public string? SalesRep { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    [StringLength(20)]
    public string QuantityPerUnit { get; set; } = null!;

    public float Discount { get; set; }

    [Column(TypeName = "money")]
    public decimal? ExtendedPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Freight { get; set; }
}
