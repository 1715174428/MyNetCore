using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class EntityTypeConfiguration<T>:IMyEntityTypeConfiguration <T>where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);
        public void Map(ModelBuilder builder)
        {
            
            Map(builder.Entity<T>());
        }
    }
     
}
