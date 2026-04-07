using Kamaradas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kamaradas.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Code).IsRequired();

            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Username).IsRequired();

            builder.Property(x => x.LicenceID).IsRequired();

            builder.Property(x => x.Score).IsRequired();
            builder.Property(x => x.ScoreToWithdraw).IsRequired();

            builder.Property(x => x.Dad_1).IsRequired();
            builder.Property(x => x.Dad_2).IsRequired();
            builder.Property(x => x.Dad_3).IsRequired();
            builder.Property(x => x.Dad_4).IsRequired();
            builder.Property(x => x.Dad_5).IsRequired();
            builder.Property(x => x.Dad_6).IsRequired();
            builder.Property(x => x.Dad_7).IsRequired();
        }
    }
}