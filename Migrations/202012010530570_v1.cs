namespace Academia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Pessoa",
                c => new
                    {
                        Pessoa_ID = c.Int(nullable: false, identity: true),
                        TipoPessoa = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Usuario_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Pessoa_ID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Codigo)
                .Index(t => t.Usuario_Codigo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        criadoEm = c.DateTime(nullable: false),
                        dataMarcada = c.DateTime(),
                        aluno_Codigo = c.Int(),
                        professor_Codigo = c.Int(),
                        venda_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.TB_Aluno", t => t.aluno_Codigo)
                .ForeignKey("dbo.TB_Professor", t => t.professor_Codigo)
                .ForeignKey("dbo.TB_CARRINHO", t => t.venda_Codigo)
                .Index(t => t.aluno_Codigo)
                .Index(t => t.professor_Codigo)
                .Index(t => t.venda_Codigo);
            
            CreateTable(
                "dbo.TB_CARRINHO",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        Pessoa_ID = c.Int(nullable: false),
                        Produto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.TB_Pessoa", t => t.Pessoa_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_PRODUTO", t => t.Produto_ID, cascadeDelete: true)
                .Index(t => t.Pessoa_ID)
                .Index(t => t.Produto_ID);
            
            CreateTable(
                "dbo.TB_PRODUTO",
                c => new
                    {
                        Produto_ID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Produto_ID);
            
            CreateTable(
                "dbo.TB_Avaliacao",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        StatusAvaliacao = c.String(),
                        Aluno_ID = c.Int(nullable: false),
                        dtCriado = c.DateTime(nullable: false),
                        dtMarcado = c.DateTime(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.TB_Aluno", t => t.Aluno_ID)
                .Index(t => t.Aluno_ID);
            
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
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.TB_Aluno", t => t.aluno_Codigo)
                .Index(t => t.aluno_Codigo);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TB_Aluno",
                c => new
                    {
                        Pessoa_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pessoa_ID)
                .ForeignKey("dbo.TB_Pessoa", t => t.Pessoa_ID)
                .Index(t => t.Pessoa_ID);
            
            CreateTable(
                "dbo.TB_Professor",
                c => new
                    {
                        Pessoa_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pessoa_ID)
                .ForeignKey("dbo.TB_Pessoa", t => t.Pessoa_ID)
                .Index(t => t.Pessoa_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_Professor", "Pessoa_ID", "dbo.TB_Pessoa");
            DropForeignKey("dbo.TB_Aluno", "Pessoa_ID", "dbo.TB_Pessoa");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.TB_IMC", "aluno_Codigo", "dbo.TB_Aluno");
            DropForeignKey("dbo.TB_Avaliacao", "Aluno_ID", "dbo.TB_Aluno");
            DropForeignKey("dbo.Usuarios", "venda_Codigo", "dbo.TB_CARRINHO");
            DropForeignKey("dbo.TB_CARRINHO", "Produto_ID", "dbo.TB_PRODUTO");
            DropForeignKey("dbo.TB_CARRINHO", "Pessoa_ID", "dbo.TB_Pessoa");
            DropForeignKey("dbo.TB_Pessoa", "Usuario_Codigo", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "professor_Codigo", "dbo.TB_Professor");
            DropForeignKey("dbo.Usuarios", "aluno_Codigo", "dbo.TB_Aluno");
            DropIndex("dbo.TB_Professor", new[] { "Pessoa_ID" });
            DropIndex("dbo.TB_Aluno", new[] { "Pessoa_ID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TB_IMC", new[] { "aluno_Codigo" });
            DropIndex("dbo.TB_Avaliacao", new[] { "Aluno_ID" });
            DropIndex("dbo.TB_CARRINHO", new[] { "Produto_ID" });
            DropIndex("dbo.TB_CARRINHO", new[] { "Pessoa_ID" });
            DropIndex("dbo.Usuarios", new[] { "venda_Codigo" });
            DropIndex("dbo.Usuarios", new[] { "professor_Codigo" });
            DropIndex("dbo.Usuarios", new[] { "aluno_Codigo" });
            DropIndex("dbo.TB_Pessoa", new[] { "Usuario_Codigo" });
            DropTable("dbo.TB_Professor");
            DropTable("dbo.TB_Aluno");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.TB_IMC");
            DropTable("dbo.TB_Avaliacao");
            DropTable("dbo.TB_PRODUTO");
            DropTable("dbo.TB_CARRINHO");
            DropTable("dbo.Usuarios");
            DropTable("dbo.TB_Pessoa");
        }
    }
}
