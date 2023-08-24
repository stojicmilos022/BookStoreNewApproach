using CoddingWiki_DataAcess.FluentConfig;
using CoddingWiki_Model.Models;
using CoddingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoddingWiki_DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //: base(options)
        //{
        //}
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }


        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }


        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Author { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }

        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=SM-PC\\SQL2022;Database=CoddingWiki;TrustServerCertificate=True;Trusted_Connection=True")
            //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id }); ;

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m ,Publisher_Id=1},
                new Book { BookId = 2, Title = "Fortune of time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 2 }
                );

            var bookList = new Book[]
            {
                new Book { BookId=3,Title="Fake sunday", ISBN="77652",Price=20.99m,Publisher_Id=3},
                new Book { BookId = 4 , Title = "Cookie jar", ISBN = "CC12B12", Price =25.99m,Publisher_Id=2 },
                new Book { BookId = 5 , Title = "Cloudy Forest", ISBN = "90392B33", Price =40.99m,Publisher_Id=1 }
            };

            modelBuilder.Entity<Publisher>().HasData(
             new Publisher { Publisher_Id = 1, Name = "Milos", Location="Indjija" },
             new Publisher { Publisher_Id = 2, Name = "Paja", Location = "Indjija" },
             new Publisher { Publisher_Id = 3, Name = "Zika", Location = "Indjija" }
            );
            modelBuilder.Entity<Book>().HasData(bookList);
            base.OnModelCreating(modelBuilder);

        }
    }
}
