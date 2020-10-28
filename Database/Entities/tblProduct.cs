﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public partial class tblProduct
    {
        [Key]
        public Guid ProductId { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public Guid? ProductSizeId { get; set; }
        public Guid? ProductSuitTypeId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public Guid? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}