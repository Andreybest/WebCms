using System.Data.Entity.ModelConfiguration;

namespace WebCms.ORM.Models.Mapping
{
    public class PageMap : EntityTypeConfiguration<Page>
    {
        public PageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PageName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Page");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PageName).HasColumnName("PageName");
            this.Property(t => t.PageOrder).HasColumnName("PageOrder");
        }
    }
}
