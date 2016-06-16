using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookLibrary.Domain.Book;

namespace BookLibrary.Repository.EntityFramework.Configurations
{
    public class BookTypeConfiguration : EntityTypeConfiguration<Book>
    {
        public BookTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}