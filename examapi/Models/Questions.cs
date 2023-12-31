﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace examapi.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Body { get; set; }
        [Required]
        [Column("type")]
        [StringLength(50)]
        [Unicode(false)]
        public string Type { get; set; }
        [Column("test_id")]
        public int TestId { get; set; }

        [ForeignKey("TestId")]
        [InverseProperty("Questions")]
        public virtual Test Test { get; set; }
        [InverseProperty("Qes")]
        public virtual ICollection<Answers> Answers { get; set; }
    }
}