using Kamaradas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kamaradas.Data.Map
{
    public class MoneyMap : IEntityTypeConfiguration<MoneyModel>
    {
        public void Configure(EntityTypeBuilder<MoneyModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.OwnerCPF).IsRequired();
            builder.Property(x => x.Score).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.Property(x => x.RequestDate).IsRequired();
            builder.Property(x => x.FinishDate).IsRequired();

            builder.Property(x => x.Finished).IsRequired();
        }
    }
}