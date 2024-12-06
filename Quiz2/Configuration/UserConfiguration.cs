using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz2.Entities;

namespace Quiz2.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>
            {
                new User(){Id=1,FirstName="ali",LastName="jafari"},
                new User(){Id=2,FirstName="erfan",LastName="joharzadeh"},
            });
        }
    }
}
