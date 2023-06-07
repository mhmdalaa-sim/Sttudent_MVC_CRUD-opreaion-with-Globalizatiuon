using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCTASK.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SName")]
    [StringLength(255)]
    [Unicode(false)]
    [Required]
    public string? Sname { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required]
    public string? Gender { get; set; }

    [Column(TypeName = "date")]
    [Required]
    public DateTime? Dateofbirth { get; set; }

    [Column("city")]
    [StringLength(255)]
    [Unicode(false)]
    [Required]
    public string? City { get; set; }

    [Column("Is_enrolled")]
    public bool? IsEnrolled { get; set; }
}
