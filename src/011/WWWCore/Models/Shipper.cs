using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

public partial class Shipper
{
    [Key]
    [Column("ShipperID")]
    public int ShipperId { get; set; }

    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [StringLength(24)]
    public string Phone { get; set; } = null!;

    [InverseProperty("ShipViaNavigation")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
