using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerProgramDemo.Models.Entities
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        //Navigation Properties
        public List<UserNote>? UserNotes { get; set; }
        public List<UserAddress>? UserAddresses { get; set; }

        public UserSerialNo? UserSerialNo { get; set; }
        public ICollection<SkillUser>? SkillUsers { get; set; }

    }
}
