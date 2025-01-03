using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Domain.Core.Quiz2.Transaction.Entities.Transaction>
    {


        public void Configure(EntityTypeBuilder<Domain.Core.Quiz2.Transaction.Entities.Transaction> builder)
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
