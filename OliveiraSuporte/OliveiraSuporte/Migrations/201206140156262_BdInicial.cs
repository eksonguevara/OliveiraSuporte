namespace OliveiraSuporte.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BdInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        NomeEmpresa = c.String(),
                        Email = c.String(),
                        Telefone = c.String(nullable: false),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false, maxLength: 20),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("Cliente");
        }
    }
}
