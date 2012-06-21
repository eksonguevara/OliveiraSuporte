using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OliveiraSuporte.Areas.painel.Models;
using OliveiraSuporte.Models;

namespace OliveiraSuporte.Util
{
    public class DbComun : DbContext

    {
        public DbComun():base("OliveiraSuporte")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Fonte> Fontes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbComun,Migrations.Configuration>());
        }
    }
}