using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Config
{
    public class UserConfig : EntityTypeConfiguration<UserInfo>
    {
        public override void Map(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("T_UserInfos");
        }
    }
}
