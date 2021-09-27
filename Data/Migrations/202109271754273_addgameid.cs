namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgameid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contract", new[] { "Game_Id" });
            AlterColumn("dbo.Contract", "Game_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contract", "Game_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contract", new[] { "Game_Id" });
            AlterColumn("dbo.Contract", "Game_Id", c => c.Int());
            CreateIndex("dbo.Contract", "Game_Id");
        }
    }
}
