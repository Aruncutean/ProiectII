using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectII.Models
{
    public class MyModel
    {
        [Required]
        public List<Category> categories { get; set; }
        [Required]
        public Product product { get; set; }
        [Required] public OrderItem orderItem { get; set; }
        [Required] public Order order { get; set; }
        [Required]
        public User userC { get; set; }
        [Required] public List<Product> products { get; set; }
        [Required] public List<UserMY> user { get; set; }
        [Required] public List<OrderItem> orderItems { get; set; }
        [Required] public List<Order> orders { get; set; }

        public decimal price;

        public class UserMY
        {
            public string page { get; set; }
            public string name { get; set; }

    

        }
    }
}