using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Config.BaseConfigurations
{
    internal class BaseEntityConfigurations<TEntity, Tkey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<Tkey> where Tkey : IEquatable<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id).ValueGeneratedOnAdd();
        }
    }
}
