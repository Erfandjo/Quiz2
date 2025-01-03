using App.Domain.Core.Quiz2.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration
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
