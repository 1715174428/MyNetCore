using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Microsoft.EntityFrameworkCore
{
   public interface IMyEntityTypeConfiguration
    {
        void Map(ModelBuilder builder);
    }
    public interface IMyEntityTypeConfiguration<T>: IMyEntityTypeConfiguration where T:class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
