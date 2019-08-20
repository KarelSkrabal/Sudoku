﻿using System.Data.Entity;

namespace SudokuUI
{
    class PuzzleContext : DbContext
    {
        public DbSet<Puzzle> PuzzleCells { get; set; }
        public PuzzleContext() : base("name=PuzzleDBConnectionString")
        {

        }
        
    }
}