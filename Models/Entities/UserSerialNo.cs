namespace SummerProgramDemo.Models.Entities
{
    public class UserSerialNo
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
