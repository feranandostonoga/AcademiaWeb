namespace Academia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_Avaliacao", "altura", c => c.String());
            AlterColumn("dbo.TB_Avaliacao", "peso", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_Avaliacao", "peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TB_Avaliacao", "altura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
