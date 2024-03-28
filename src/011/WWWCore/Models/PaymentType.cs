using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

public partial class PaymentType
{
    [Key]
    [Column("PaymentTypeID")]
    public byte PaymentTypeId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string PaymentTypeDescription { get; set; } = null!;

    [InverseProperty("PaymentType")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
