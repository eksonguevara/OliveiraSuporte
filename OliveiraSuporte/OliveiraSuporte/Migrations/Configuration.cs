namespace OliveiraSuporte.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OliveiraSuporte.Util.DbComun>
    {
        public Configuration()
        {
            //Habilita migração automatica para parar so trocar por false.
            AutomaticMigrationsEnabled = true;
            //Permite apagar meus dados sem solicitação.
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OliveiraSuporte.Util.DbComun context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
