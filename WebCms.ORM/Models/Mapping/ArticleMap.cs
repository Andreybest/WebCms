using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebCms.ORM.Models.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

        // Table & Column Mappings
            this.ToTable("Article");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.PageId).HasColumnName("PageId");
            this.Property(t => t.ArticleOrder).HasColumnName("ArticleOrder");

            // Relationships
            this.HasRequired(t => t.Page)
                .WithMany(t => t.Articles)
                .HasForeignKey(d => d.PageId);

        }
    }
}
