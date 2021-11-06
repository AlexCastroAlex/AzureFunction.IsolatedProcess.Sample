using Microsoft.EntityFrameworkCore;
using Repository.EF.UoW.Core.Models;

namespace AzureFunction.DependyInjection.Sample
{
    public class DBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<Book>? Books { get; set; }
        public virtual DbSet<Catalog>? Catalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}