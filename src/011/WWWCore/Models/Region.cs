﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

public partial class Region
{
    [Key]
    [Column("RegionID")]
    public int RegionId { get; set; }

    [StringLength(50)]
    public string RegionDescription { get; set; } = null!;

    [InverseProperty("Region")]
    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
