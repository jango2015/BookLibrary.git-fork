using System.Data.Common;
using System.Data.Entity;
using BookLibrary.Domain.Book;
using BookLibrary.Domain.BorrowedProcess;
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
            modelBuilder.Entity<BookLibraryProcess>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<BorrowedRecord>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<ReturnedRecord>().Map(m => m.MapInheritedProperties());

            modelBuilder.Configurations
                .Add(new BookTypeConfiguration())
                .Add(new UserTypeConfiguration())
                .Add(new BookLibraryProcessTypeConfiguration())
                .Add(new BorrowRecordTypeConfiguration())
                .Add(new ReturnBookRecordTypeConfiguration())
                ;

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookLibraryProcess> BookLibraryProcesses { get; set; } 

        public DbSet<BorrowedRecord> BookBorrowedRecords { get; set; } 

        public DbSet<ReturnedRecord> BookReturnedRecords { get; set; }


    }
}