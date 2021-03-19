using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ProiectII.Models
{
    public enum Roles
    { 
        Admin,
        Client
    }
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public Roles Role { get; set; }
    }

}