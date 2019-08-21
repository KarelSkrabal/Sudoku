using SudokuUI.Models;
using System.Data.Entity;

namespace SudokuUI
{
    public class PuzzleContext : DbContext
    {
        public DbSet<Puzzle> PuzzleCells { get; set; }

        public PuzzleContext() : base("name=PuzzleDBConnectionString")
        {

        }
        
    }
}
