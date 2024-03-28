using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale.Models;

[Index("LastName", Name = "LastName")]
[Index("AddressId", Name = "UX_Employees_AddressID", IsUnique = true)]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [StringLength(10)]
    public string FirstName { get; set; } = null!;

    [StringLength(25)]
    public string? TitleOfCourtesy { get; set; }

    [StringLength(30)]
    public string? JobTitle { get; set; }

    public int? ReportsTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime HireDate { get; set; }

    [StringLength(24)]
    public string? OfficePhone { get; set; }

    [StringLength(4)]
    public string? Extension { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BirthDate { get; set; }

    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(24)]
    public string HomePhone { get; set; } = null!;

    public byte[]? Photo { get; set; }

    [StringLength(40)]
    public string? PhotoMimeType { get; set; }

    [Column(TypeName = "ntext")]
    public string? Notes { get; set; }

    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TerminationDate { get; set; }

    public bool OnLeave { get; set; }

    [StringLength(80)]
    public string? LeaveReason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReturnDate { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Employee")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("ReportsToNavigation")]
    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    [InverseProperty("SalesRep")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("ReportsTo")]
    [InverseProperty("InverseReportsToNavigation")]
    public virtual Employee? ReportsToNavigation { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Employees")]
    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
