using Microsoft.EntityFrameworkCore;
using Models;

namespace Prueba1
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {


        }



        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Machinery> Machinery { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
    }
}
