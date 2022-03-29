using HIS.Entity;
using HIS.RespDTO;
using Microsoft.EntityFrameworkCore;

namespace HIS
{
    public class DataContext:DbContext
    {
        private readonly string constr;
        public DataContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            constr = config.GetConnectionString("mysql");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(constr);
        }
        public DbSet<RespDept2DTO> Dept2 { get; set; }
        public DbSet<RespDoctorDTO> Doctor { get; set; }
        public DbSet<RespDepDocDTO> DepDoc { get; set; }
        public DbSet<RespScheduleDTO> Schedules { get; set; }
        public DbSet<RespSourceDTO> Sources { get; set; }
        public DbSet<EntCard> Card { get; set; }
        public DbSet<EntOrder> Order { get; set; }
        public DbSet<EntDictionary> Dictionaries { get; set; }


    }
}
