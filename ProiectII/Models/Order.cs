using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ProiectII.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }

    
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; } // <> inseamna generics, adica stabilesti un nou Obiect cu elemente de tip-ul ce scrii intre < >
    }

}