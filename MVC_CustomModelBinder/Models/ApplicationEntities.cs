namespace MVC_CustomModelBinder.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationEntities : DbContext
    {
        public ApplicationEntities()
            : base("name=ApplicationEntities")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
