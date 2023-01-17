using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerProgramDemo.Models.Entities
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string? Address { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please Capitalize the first letter and remove any numbers and spaces")]
        [Required]
        public string? City { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please Capitalize the first letter and remove any numbers and spaces")]
        [Required]
        public string? Country { get; set; }

        //Navigation Properties
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
