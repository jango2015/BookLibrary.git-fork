using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookLibrary.Domain.BorrowedProcess;

namespace BookLibrary.Repository.EntityFramework.Configurations
{
    public class BookBorrowProcessTypeConfiguration: EntityTypeConfiguration<BookBorrowedProcess>
    {
        public BookBorrowProcessTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}