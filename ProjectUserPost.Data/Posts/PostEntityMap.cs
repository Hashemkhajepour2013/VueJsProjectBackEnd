using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectUserPost.Entities;

namespace ProjectUserPost.Data.Posts
{
    public class PostEntityMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Title).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.Body).HasMaxLength(500).IsRequired();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.Posts)
                .HasForeignKey(_ => _.userId);
            
        }
    }
}
