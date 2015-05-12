using System.Data.Entity.ModelConfiguration;

namespace WebCms.ORM.Models.Mapping
{
    public class ArticleAnswerMap : EntityTypeConfiguration<ArticleAnswer>
    {
        public ArticleAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AnswerText)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("ArticleAnswer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ArticleId).HasColumnName("ArticleId");
            this.Property(t => t.AnswerText).HasColumnName("AnswerText");
            this.Property(t => t.AnswerType).HasColumnName("AnswerType");

            // Relationships
            this.HasRequired(t => t.Article)
                .WithMany(t => t.ArticleAnswers)
                .HasForeignKey(d => d.ArticleId);

        }
    }
}
