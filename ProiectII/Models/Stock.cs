using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectII.Models
{
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime Date { get; set; } //data la care am adaugat stocul
        public virtual Product Product { get; set; }
    }
}