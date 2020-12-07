namespace Academia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_IMC", "aluno_Codigo", "dbo.TB_Aluno");
            DropIndex("dbo.TB_IMC", new[] { "aluno_Codigo" });
            AddColumn("dbo.TB_Avaliacao", "altura", c => c.Double(nullable: false));
            AddColumn("dbo.TB_Avaliacao", "peso", c => c.Double(nullable: false));
            AddColumn("dbo.TB_Avaliacao", "imc", c => c.String());
            AddColumn("dbo.TB_Avaliacao", "resultadoIMC", c => c.String());
            DropTable("dbo.TB_IMC");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TB_IMC",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        altura = c.Double(nullable: false),
                        peso = c.Double(nullable: false),
                        dtCriado = c.DateTime(nullable: false),
                        imcResultado = c.String(),
                        resultado = c.String(),
                        aluno_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo);
            
            DropColumn("dbo.TB_Avaliacao", "resultadoIMC");
            DropColumn("dbo.TB_Avaliacao", "imc");
            DropColumn("dbo.TB_Avaliacao", "peso");
            DropColumn("dbo.TB_Avaliacao", "altura");
            CreateIndex("dbo.TB_IMC", "aluno_Codigo");
            AddForeignKey("dbo.TB_IMC", "aluno_Codigo", "dbo.TB_Aluno", "Pessoa_ID");
        }
    }
}
