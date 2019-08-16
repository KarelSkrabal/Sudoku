namespace SudokuUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Puzzles",
                c => new
                    {
                        puzzleId = c.Int(nullable: false, identity: true),
                        cell = c.String(),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.puzzleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Puzzles");
        }
    }
}
