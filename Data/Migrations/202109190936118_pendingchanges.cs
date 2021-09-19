namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingchanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WordWordSet", newName: "WordSetWord");
            DropPrimaryKey("dbo.WordSetWord");
            AddPrimaryKey("dbo.WordSetWord", new[] { "WordSet_Id", "Word_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WordSetWord");
            AddPrimaryKey("dbo.WordSetWord", new[] { "Word_Id", "WordSet_Id" });
            RenameTable(name: "dbo.WordSetWord", newName: "WordWordSet");
        }
    }
}
