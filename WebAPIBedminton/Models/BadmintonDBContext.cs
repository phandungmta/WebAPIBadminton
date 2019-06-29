namespace WebAPIBedminton.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BadmintonDBContext : DbContext
    {
        public BadmintonDBContext()
            : base("name=BadmintonDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Bill_Details> Bill_Details { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<News_Type> News_Type { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.Account)
                .WillCascadeOnDelete();

            modelBuilder.Entity<News_Type>()
                .HasMany(e => e.News)
                .WithRequired(e => e.News_Type)
                .HasForeignKey(e => e.NewsTypeID);
        }
    }
}
