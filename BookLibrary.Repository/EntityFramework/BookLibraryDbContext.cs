using System.Data.Common;
using System.Data.Entity;
using BookLibrary.Domain.Book;
using BookLibrary.Domain.BookManageProcess;
using BookLibrary.Domain.User;
using BookLibrary.Repository.EntityFramework.Configurations;

namespace BookLibrary.Repository.EntityFramework
{
    public class BookLibraryDbContext : DbContext
    {
        public const string ConnectionString = "BookLibrary";

        public BookLibraryDbContext()
            : base(ConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public BookLibraryDbContext(DbConnection connection) : base(connection, true)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        override protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<User>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<BookManageProcess>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<BorrowRecord>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<ReturnBookRecord>().Map(m => m.MapInheritedProperties());

            modelBuilder.Configurations
                .Add(new BookTypeConfiguration())
                .Add(new UserTypeConfiguration())
                .Add(new BookManageProcessTypeConfiguration())
                .Add(new BorrowRecordTypeConfiguration())
                .Add(new ReturnBookRecordTypeConfiguration())
                ;

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookManageProcess> BookManageProcesses { get; set; } 

        public DbSet<BorrowRecord> BorrowRecords { get; set; } 

        public DbSet<ReturnBookRecord> ReturnBookRecords { get; set; }


    }
}