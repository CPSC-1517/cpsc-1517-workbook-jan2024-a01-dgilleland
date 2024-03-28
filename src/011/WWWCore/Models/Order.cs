using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Index("CustomerId", Name = "CustomerID")]
[Index("CustomerId", Name = "CustomersOrders")]
[Index("SalesRepId", Name = "EmployeeID")]
[Index("SalesRepId", Name = "EmployeesOrders")]
[Index("OrderDate", Name = "OrderDate")]
public partial class Order
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("SalesRepID")]
    public int? SalesRepId { get; set; }

    [Column("CustomerID")]
    [StringLength(5)]
    public string CustomerId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDueDate { get; set; }

    [Column(TypeName = "money")]
    public decimal? Freight { get; set; }

    public bool Shipped { get; set; }

    [StringLength(40)]
    public string? ShipName { get; set; }

    [Column("ShipAddressID")]
    public int? ShipAddressId { get; set; }

    [StringLength(250)]
    public string? Comments { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("SalesRepId")]
    [InverseProperty("Orders")]
    public virtual Employee? SalesRep { get; set; }

    [ForeignKey("ShipAddressId")]
    [InverseProperty("Orders")]
    public virtual Address? ShipAddress { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
