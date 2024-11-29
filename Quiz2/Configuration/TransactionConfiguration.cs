using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace Quiz2.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Entities.Transaction>
    {
      

        public void Configure(EntityTypeBuilder<Entities.Transaction> builder)
        {
            builder.HasKey(x => x.TransactionId);
            builder.HasOne(x => x.SourceCard).WithMany(x => x.Transactions).HasForeignKey(x => x.SourceCardNumber);
            
        }
    }
}
