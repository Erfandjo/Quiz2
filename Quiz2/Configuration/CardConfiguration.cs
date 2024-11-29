using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz2.Entities;

namespace Quiz2.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.CardNumber);
            builder.HasMany(x => x.Transactions).WithOne(x => x.SourceCard).HasForeignKey(x => x.SourceCardNumber);
           
        }
    }
}
