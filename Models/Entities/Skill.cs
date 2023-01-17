namespace SummerProgramDemo.Models.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Skillss { get; set; }
        public List<SkillUser>? SkillUsers { get; set; }
    }
}
