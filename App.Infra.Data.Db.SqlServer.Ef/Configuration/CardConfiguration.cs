using App.Domain.Core.Quiz2.Card.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.CardNumber);
            builder.HasData(new List<Card>()
        {
            new Card() {UserId = 1 ,CardNumber = "6219861932608341" , HolderName = "BlueCard" ,Password = "1234" ,Balance = 500},
            new Card() {UserId = 2 ,CardNumber = "2596478521359865" , HolderName = "MeliCard" ,Password = "1234" ,Balance = 100},
        });

        }
    }
}
