using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookLibrary.Domain.BookManageProcess;

namespace BookLibrary.Repository.EntityFramework.Configurations
{
    public class ReturnBookRecordTypeConfiguration: EntityTypeConfiguration<ReturnBookRecord>
    {
        public ReturnBookRecordTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}