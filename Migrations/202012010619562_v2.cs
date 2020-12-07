namespace Academia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_Avaliacao", "Aluno_ID", "dbo.TB_Aluno");
            DropIndex("dbo.TB_Avaliacao", new[] { "Aluno_ID" });
            AddColumn("dbo.TB_Avaliacao", "Pessoa_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.TB_Avaliacao", "Pessoa_ID");
            AddForeignKey("dbo.TB_Avaliacao", "Pessoa_ID", "dbo.TB_Pessoa", "Pessoa_ID", cascadeDelete: true);
            DropColumn("dbo.TB_Avaliacao", "Aluno_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_Avaliacao", "Aluno_ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TB_Avaliacao", "Pessoa_ID", "dbo.TB_Pessoa");
            DropIndex("dbo.TB_Avaliacao", new[] { "Pessoa_ID" });
            DropColumn("dbo.TB_Avaliacao", "Pessoa_ID");
            CreateIndex("dbo.TB_Avaliacao", "Aluno_ID");
            AddForeignKey("dbo.TB_Avaliacao", "Aluno_ID", "dbo.TB_Aluno", "Pessoa_ID");
        }
    }
}
