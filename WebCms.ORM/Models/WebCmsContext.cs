using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebCms.ORM.Models.Mapping;

namespace WebCms.ORM.Models
{
    public partial class WebCmsContext : DbContext
    {
        static WebCmsContext()
        {
            Database.SetInitializer<WebCmsContext>(null);
        }

        public WebCmsContext()
            : base("Name=WebCmsContext")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<StyleCss> StyleCsses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new PageMap());
            modelBuilder.Configurations.Add(new StyleCssMap());
        }
    }
}
