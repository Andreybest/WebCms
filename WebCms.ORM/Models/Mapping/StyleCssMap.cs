using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebCms.ORM.Models.Mapping
{
    public class StyleCssMap : EntityTypeConfiguration<StyleCss>
    {
        public StyleCssMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Url)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StyleCss");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.PageId).HasColumnName("PageId");

            // Relationships
            this.HasRequired(t => t.Page)
                .WithMany(t => t.StyleCsses)
                .HasForeignKey(d => d.PageId);

        }
    }
}
