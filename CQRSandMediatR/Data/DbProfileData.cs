using CQRSandMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSandMediatR.Data
{
    public class DbProfileData : DbContext
    {
        protected readonly IConfiguration configuration;

        public DbProfileData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ProfileModel> Profiles { get; set; }
    }
}
