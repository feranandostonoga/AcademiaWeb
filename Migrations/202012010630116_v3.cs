namespace Academia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_Avaliacao", "Professor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_Avaliacao", "Professor");
        }
    }
}
