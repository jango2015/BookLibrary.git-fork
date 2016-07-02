using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookLibrary.Domain.BorrowedProcess;

namespace BookLibrary.Repository.EntityFramework.Configurations
{
    public class ReturnBookRecordTypeConfiguration: EntityTypeConfiguration<ReturnedRecord>
    {
        public ReturnBookRecordTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}