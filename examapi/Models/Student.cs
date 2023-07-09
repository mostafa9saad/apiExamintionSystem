﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace examapi.Models
{
    public partial class Student
    {
        public Student()
        {
            Exam = new HashSet<Exam>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("FName")]
        [StringLength(50)]
        [Unicode(false)]
        public string Fname { get; set; }
        [Required]
        [Column("LName")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lname { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }
        [Required]
        [StringLength(50), MinLength(8)]
        [Unicode(false)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Role { get; set; }

        [InverseProperty("Std")]
        public virtual ICollection<Exam> Exam { get; set; }
    }
}