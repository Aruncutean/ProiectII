using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ProiectII.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]

        public virtual Order Order { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }

}