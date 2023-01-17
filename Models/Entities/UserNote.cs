using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SummerProgramDemo.Models.Entities
{
    public class UserNote
    {
        [Key]
        public int Id { get; set; }
        public string? Note { get; set; }

        //Navigation Properties
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}