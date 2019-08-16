namespace SudokuUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Puzzles",
                c => new
                    {
                        iD = c.Int(nullable: false, identity: true),
                        puzzleId = c.Int(nullable: false),
                        row = c.Int(nullable: false),
                        col = c.Int(nullable: false),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.iD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Puzzles");
        }
    }
}
