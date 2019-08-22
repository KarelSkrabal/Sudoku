using SudokuUI.Migrations;
using System.Data.Entity;

namespace SudokuUI
{
    public class PuzzleContext : DbContext
    {
        public DbSet<Puzzle> PuzzleCells { get; set; }

        public PuzzleContext() : base("name=PuzzleDBConnectionString")
        {
            //var databaseInitializer = new DatabaseInitializer<PuzzleContext>();
            //Database.SetInitializer(databaseInitializer);
            Database.SetInitializer(new PuzzleDbInitializer());
        }

    }
}
