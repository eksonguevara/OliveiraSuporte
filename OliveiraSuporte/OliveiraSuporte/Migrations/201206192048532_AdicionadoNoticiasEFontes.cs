namespace OliveiraSuporte.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoNoticiasEFontes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Noticia",
                c => new
                    {
                        NoticiaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Conteudo = c.String(),
                        Fonte_FonteId = c.Int(),
                    })
                .PrimaryKey(t => t.NoticiaId)
                .ForeignKey("Fonte", t => t.Fonte_FonteId)
                .Index(t => t.Fonte_FonteId);
            
            CreateTable(
                "Fonte",
                c => new
                    {
                        FonteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Contato = c.String(),
                    })
                .PrimaryKey(t => t.FonteId);
            
        }
        
        public override void Down()
        {
            DropIndex("Noticia", new[] { "Fonte_FonteId" });
            DropForeignKey("Noticia", "Fonte_FonteId", "Fonte");
            DropTable("Fonte");
            DropTable("Noticia");
        }
    }
}
