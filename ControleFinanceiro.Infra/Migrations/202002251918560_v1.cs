namespace ControleFinanceiro.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lancamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        Categoria = c.Int(nullable: false),
                        LancamentoMensal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destino = c.String(nullable: false, maxLength: 60),
                        Porcentagem = c.Single(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meta");
            DropTable("dbo.Lancamento");
        }
    }
}
