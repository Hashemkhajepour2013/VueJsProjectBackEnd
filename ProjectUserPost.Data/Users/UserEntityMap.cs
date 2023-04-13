using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Users
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Name).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.Email).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.UserName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.Website).HasMaxLength(100).IsRequired(false);
            builder.Property(_ => _.Phone).HasMaxLength(11).IsRequired(false);
            builder.Property(_ => _.Company).HasMaxLength(100).IsRequired(false);
        }
    }
}
