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
                        Group = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        ProfileImage = c.Binary(),
                        Residence = c.String(),
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
                        UserActive = c.Boolean(nullable: false),
                        User_Rol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Game_Review = c.String(),
                        User_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game_Name = c.String(),
                        Game_Start = c.DateTime(),
                        Game_Eind = c.DateTime(),
                        Location = c.String(),
                        Archived = c.Boolean(nullable: false),
                        RandomWiner = c.Int(),
                        BestKill = c.Int(),
                        Maker_Id = c.Int(nullable: false),
                        WordSet_Id = c.Int(),
                        GameType_Id = c.Int(),
                        RuleSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameType", t => t.GameType_Id)
                .ForeignKey("dbo.RuleSet", t => t.RuleSet_Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .ForeignKey("dbo.WordSet", t => t.WordSet_Id)
                .Index(t => t.Maker_Id)
                .Index(t => t.WordSet_Id)
                .Index(t => t.GameType_Id)
                .Index(t => t.RuleSet_Id);
            
            CreateTable(
                "dbo.GameType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameType_Name = c.String(),
                        GameType_Description = c.String(),
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.RuleSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RuleSet_Name = c.String(),
                        RuleSet_public = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.Rule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rule_Name = c.String(),
                        Rule_Description = c.String(),
                        Rule_public = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.WordSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordSet_Name = c.String(),
                        WordSet_public = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word_Name = c.String(),
                        Word_public = c.Boolean(nullable: false),
                        Maker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Maker_Id)
                .Index(t => t.Maker_Id);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Eliminate_Id = c.Int(nullable: false),
                        Eliminator_Id = c.Int(nullable: false),
                        Word_Id = c.Int(),
                        EliminatedTime = c.DateTime(),
                        Story = c.String(),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.GamePlayer", t => t.Eliminate_Id)
                .ForeignKey("dbo.GamePlayer", t => t.Eliminator_Id)
                .ForeignKey("dbo.Word", t => t.Word_Id)
                .Index(t => t.Eliminate_Id)
                .Index(t => t.Eliminator_Id)
                .Index(t => t.Word_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.GamePlayer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.RuleRuleSet",
                c => new
                    {
                        Rule_Id = c.Int(nullable: false),
                        RuleSet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rule_Id, t.RuleSet_Id })
                .ForeignKey("dbo.Rule", t => t.Rule_Id)
                .ForeignKey("dbo.RuleSet", t => t.RuleSet_Id)
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
                .ForeignKey("dbo.Word", t => t.Word_Id)
                .ForeignKey("dbo.WordSet", t => t.WordSet_Id)
                .Index(t => t.Word_Id)
                .Index(t => t.WordSet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluation", "User_Id", "dbo.User");
            DropForeignKey("dbo.Evaluation", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.Game", "WordSet_Id", "dbo.WordSet");
            DropForeignKey("dbo.WordWordSet", "WordSet_Id", "dbo.WordSet");
            DropForeignKey("dbo.WordWordSet", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Word", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.Contract", "Word_Id", "dbo.Word");
            DropForeignKey("dbo.Contract", "Eliminator_Id", "dbo.GamePlayer");
            DropForeignKey("dbo.Contract", "Eliminate_Id", "dbo.GamePlayer");
            DropForeignKey("dbo.GamePlayer", "User_Id", "dbo.User");
            DropForeignKey("dbo.GamePlayer", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.Contract", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.WordSet", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.Game", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.Game", "RuleSet_Id", "dbo.RuleSet");
            DropForeignKey("dbo.RuleSet", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.Rule", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.RuleRuleSet", "RuleSet_Id", "dbo.RuleSet");
            DropForeignKey("dbo.RuleRuleSet", "Rule_Id", "dbo.Rule");
            DropForeignKey("dbo.Game", "GameType_Id", "dbo.GameType");
            DropForeignKey("dbo.GameType", "Maker_Id", "dbo.User");
            DropForeignKey("dbo.Account", "User_Id", "dbo.User");
            DropIndex("dbo.WordWordSet", new[] { "WordSet_Id" });
            DropIndex("dbo.WordWordSet", new[] { "Word_Id" });
            DropIndex("dbo.RuleRuleSet", new[] { "RuleSet_Id" });
            DropIndex("dbo.RuleRuleSet", new[] { "Rule_Id" });
            DropIndex("dbo.GamePlayer", new[] { "Game_Id" });
            DropIndex("dbo.GamePlayer", new[] { "User_Id" });
            DropIndex("dbo.Contract", new[] { "Game_Id" });
            DropIndex("dbo.Contract", new[] { "Word_Id" });
            DropIndex("dbo.Contract", new[] { "Eliminator_Id" });
            DropIndex("dbo.Contract", new[] { "Eliminate_Id" });
            DropIndex("dbo.Word", new[] { "Maker_Id" });
            DropIndex("dbo.WordSet", new[] { "Maker_Id" });
            DropIndex("dbo.Rule", new[] { "Maker_Id" });
            DropIndex("dbo.RuleSet", new[] { "Maker_Id" });
            DropIndex("dbo.GameType", new[] { "Maker_Id" });
            DropIndex("dbo.Game", new[] { "RuleSet_Id" });
            DropIndex("dbo.Game", new[] { "GameType_Id" });
            DropIndex("dbo.Game", new[] { "WordSet_Id" });
            DropIndex("dbo.Game", new[] { "Maker_Id" });
            DropIndex("dbo.Evaluation", new[] { "Game_Id" });
            DropIndex("dbo.Evaluation", new[] { "User_Id" });
            DropIndex("dbo.Account", new[] { "User_Id" });
            DropTable("dbo.WordWordSet");
            DropTable("dbo.RuleRuleSet");
            DropTable("dbo.GamePlayer");
            DropTable("dbo.Contract");
            DropTable("dbo.Word");
            DropTable("dbo.WordSet");
            DropTable("dbo.Rule");
            DropTable("dbo.RuleSet");
            DropTable("dbo.GameType");
            DropTable("dbo.Game");
            DropTable("dbo.Evaluation");
            DropTable("dbo.User");
            DropTable("dbo.Account");
        }
    }
}
