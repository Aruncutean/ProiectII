using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectII.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}