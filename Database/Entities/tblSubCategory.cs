﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public partial class tblSubCategory
    {
        [Key]
        public Guid SubCategoryId { get; set; }
        [StringLength(50)]
        public string SubCategoryName { get; set; }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        public string PhotoImage { get; set; }
        public Guid? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}