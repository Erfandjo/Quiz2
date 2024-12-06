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
            builder.HasData(new List<Card>()
        {
            new Card() {UserId = 1 ,CardNumber = "6037997568331020" , HolderName = "MeliCard" ,Password = "1234" ,Balance = 500},
            new Card() {UserId = 2 ,CardNumber = "6037997568331030" , HolderName = "MeliCard" ,Password = "1234" ,Balance = 100},
        });

        }
    }
}
