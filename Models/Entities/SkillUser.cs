using System.ComponentModel.DataAnnotations;

namespace SummerProgramDemo.Models.Entities
{
    public class SkillUser
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
