using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Models.Entities;

namespace SummerProgramDemo.Data
{
    public class UserProfileDbContext : IdentityDbContext<SummerProgramDemoUser>
    {
        public UserProfileDbContext(DbContextOptions<UserProfileDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<UserSerialNo> UserSerialNos { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
