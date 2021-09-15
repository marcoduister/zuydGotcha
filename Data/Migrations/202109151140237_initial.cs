namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Alias = c.String(),
                        Groep = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        ProfileImage = c.Binary(),
                    })
                .PrimaryKey(t => t.User_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Rol = c.Int(nullable: false),
                        UserActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Word_Id = c.Int(),
                        EliminatedTime = c.DateTime(),
                        Eliminations = c.Int(nullable: false),
                        Game_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id1)
                .ForeignKey("dbo.User", t => t.User_Id1)
                .Index(t => t.Game_Id1)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(),
                        EindTime = c.DateTime(),
                        Location = c.String(),
                        RandomWiner = c.Int(),
                        BestKill = c.Int(),
                        Archived = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                        WordSet_Id = c.Int(),
                        GameType_Id = c.Int(),
                        RuleSet_Id = c.Int(),
                        GameType_Id1 = c.Int(),
                        RuleSet_Id1 = c.Int(),
                        User_Id = c.Int(),
                        WordSet_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameType", t => t.GameType_Id1)
                .ForeignKey("dbo.RuleSet", t => t.RuleSet_Id1)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.WordSet", t => t.WordSet_Id1)
                .Index(t => t.GameType_Id1)
                .Index(t => t.RuleSet_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.WordSet_Id1);
            
            CreateTable(
                "dbo.GameType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Maker_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RuleSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Maker_Id = c.Int(nullable: false),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Rule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Maker_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WordSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Maker_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Maker_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RuleRuleSet",
                c => new
                    {
                        Rule_Id = c.Int(nullable: false),
                        RuleSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rule_Id, t.RuleSet_Id })
                .ForeignKey("dbo.Rule", t => t.Rule_Id, cascadeDelete: true)
                .ForeignKey("dbo.RuleSet", t => t.RuleSet_Id, cascadeDelete: true)
                .Index(t => t.Rule_Id)
                .Index(t => t.RuleSet_Id);
            
            CreateTable(
                "dbo.WordWordSet",
                c => new
                    {
                        Word_Id = c.Int(nullable: false),
                        WordSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Word_Id, t.WordSet_Id })
                .ForeignKey("dbo.Word", t => t.Word_Id, cascadeDelete: true)
                .ForeignKey("dbo.WordSet", t => t.WordSet_Id, cascadeDelete: true)
                .Index(t => t.Word_Id)
                .Index(t => t.WordSet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contract", "User_Id1", "dbo.User");
            DropForeignKey("dbo.WordWordSet", "WordSet_Id", "dbo.WordSet");
            DropForeignKey("dbo.WordWordSet", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Word", "User_Id", "dbo.User");
            DropForeignKey("dbo.WordSet", "User_Id", "dbo.User");
            DropForeignKey("dbo.Game", "WordSet_Id1", "dbo.WordSet");
            DropForeignKey("dbo.Game", "User_Id", "dbo.User");
            DropForeignKey("dbo.RuleSet", "User_Id", "dbo.User");
            DropForeignKey("dbo.Rule", "User_Id", "dbo.User");
            DropForeignKey("dbo.RuleRuleSet", "RuleSet_Id", "dbo.RuleSet");
            DropForeignKey("dbo.RuleRuleSet", "Rule_Id", "dbo.Rule");
            DropForeignKey("dbo.Game", "RuleSet_Id1", "dbo.RuleSet");
            DropForeignKey("dbo.GameType", "User_Id", "dbo.User");
            DropForeignKey("dbo.Game", "GameType_Id1", "dbo.GameType");
            DropForeignKey("dbo.Contract", "Game_Id1", "dbo.Game");
            DropForeignKey("dbo.Account", "User_Id", "dbo.User");
            DropIndex("dbo.WordWordSet", new[] { "WordSet_Id" });
            DropIndex("dbo.WordWordSet", new[] { "Word_Id" });
            DropIndex("dbo.RuleRuleSet", new[] { "RuleSet_Id" });
            DropIndex("dbo.RuleRuleSet", new[] { "Rule_Id" });
            DropIndex("dbo.Word", new[] { "User_Id" });
            DropIndex("dbo.WordSet", new[] { "User_Id" });
            DropIndex("dbo.Rule", new[] { "User_Id" });
            DropIndex("dbo.RuleSet", new[] { "User_Id" });
            DropIndex("dbo.GameType", new[] { "User_Id" });
            DropIndex("dbo.Game", new[] { "WordSet_Id1" });
            DropIndex("dbo.Game", new[] { "User_Id" });
            DropIndex("dbo.Game", new[] { "RuleSet_Id1" });
            DropIndex("dbo.Game", new[] { "GameType_Id1" });
            DropIndex("dbo.Contract", new[] { "User_Id1" });
            DropIndex("dbo.Contract", new[] { "Game_Id1" });
            DropIndex("dbo.Account", new[] { "User_Id" });
            DropTable("dbo.WordWordSet");
            DropTable("dbo.RuleRuleSet");
            DropTable("dbo.Word");
            DropTable("dbo.WordSet");
            DropTable("dbo.Rule");
            DropTable("dbo.RuleSet");
            DropTable("dbo.GameType");
            DropTable("dbo.Game");
            DropTable("dbo.Contract");
            DropTable("dbo.User");
            DropTable("dbo.Account");
        }
    }
}
