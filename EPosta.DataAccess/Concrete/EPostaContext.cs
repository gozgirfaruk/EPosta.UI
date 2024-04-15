using EPosta.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.DataAccess.Concrete
{
    public class EPostaContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MT6QAH6\\SQLEXPRESS; database = EpostaDb ; Integrated Security =true ");
        }

        public DbSet<AppMessage> AppMessages { get; set; }

    }
}
