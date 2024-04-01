using LearningLanguagePlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningLanguagePlatform.DATA
{
    public class UserDBContext: IdentityDbContext<User>
    {
        public UserDBContext(DbContextOptions<UserDBContext>s) : base(s)
        {

        }

        public DbSet<User> Registers { get; set; }
    }
}
