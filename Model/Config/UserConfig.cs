using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Config
{
    class UserConfig : BaseConfig,IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("T_UserInfos");
            //builder.Property(i => i.Age).IsRequired().HasMaxLength(3);
            //执行sql时候过滤掉roleid=0的
            //builder.HasQueryFilter(i => i.RoleId==0);
            builder.HasOne(e=>e.Role).WithMany().HasForeignKey(i=>i.RoleId).IsRequired();
        }
    }
}