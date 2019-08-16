namespace SudokuUI.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SudokuUI.PuzzleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SudokuUI.PuzzleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Puzzle> defaultPuzzles = new List<Puzzle>();
            defaultPuzzles.Add(new Puzzle {  puzzleId = 1, row = 0, col = 0, value = 0 });
            defaultPuzzles.Add(new Puzzle { puzzleId=1, row = 0, col = 1, value = 3 });

            context.PuzzleCells.AddRange(defaultPuzzles);
            base.Seed(context);
        }
    }
}
