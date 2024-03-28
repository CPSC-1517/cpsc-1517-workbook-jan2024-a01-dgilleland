﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

public partial class Shipment
{
    [Key]
    [Column("ShipmentID")]
    public int ShipmentId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ShippedDate { get; set; }

    public int ShipVia { get; set; }

    [Column(TypeName = "money")]
    public decimal FreightCharge { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? TrackingCode { get; set; }

    [InverseProperty("Shipment")]
    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    [ForeignKey("OrderId")]
    [InverseProperty("Shipments")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ShipVia")]
    [InverseProperty("Shipments")]
    public virtual Shipper ShipViaNavigation { get; set; } = null!;
}
