using Microsoft.EntityFrameworkCore;
using User_Manegement_System.Model;

namespace User_Manegement_System.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<tbl_user> Users { get; set; }
    }
}
