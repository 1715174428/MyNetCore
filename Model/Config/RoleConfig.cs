using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Config
{
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public override void Map(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("T_Roles");
        }
    }
}
