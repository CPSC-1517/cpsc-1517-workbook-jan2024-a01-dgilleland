using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

public partial class Address
{
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    [Column("Address")]
    [StringLength(60)]
    public string Address1 { get; set; } = null!;

    [StringLength(15)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(15)]
    public string Country { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Address")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("ShipAddress")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Address")]
    public virtual Supplier? Supplier { get; set; }
}
