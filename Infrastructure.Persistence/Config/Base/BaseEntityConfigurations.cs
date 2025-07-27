using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base
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
