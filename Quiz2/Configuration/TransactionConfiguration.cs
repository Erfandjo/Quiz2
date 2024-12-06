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
            
            builder.ToTable("Transactions");

            builder.HasOne(x => x.SourceCard)
                .WithMany(x => x.TransactionsAsSource)
                .HasForeignKey(x => x.SourceCardNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DestinationCard)
                .WithMany(x => x.TransactionsAsDestination)
                .HasForeignKey(x => x.DestinationCardNumber)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
