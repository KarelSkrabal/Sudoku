using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCLI
{
    public class InputParser
    {
        public static void Generate()
        {
            Dictionary<int, int[,]> inputs = new Dictionary<int, int[,]>();
            inputs.Add(0, new[,] {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            });

            inputs.Add(1, new[,] {
            {2,0,0,0,8,0,3,0,0},
            {0,6,0,0,7,0,0,8,4},
            {0,3,0,5,0,0,2,0,9},
            {0,0,0,1,0,5,4,0,8},
            {0,0,0,0,0,0,0,0,0},
            {4,0,2,7,0,6,0,0,0},
            {3,0,1,0,0,7,0,4,0},
            {7,2,0,0,4,0,0,6,0},
            {0,0,4,0,1,0,0,0,3}
            });

            inputs.Add(2, new[,] {
                {0,0,0,0,0,0,9,0,7},
                {0,0,0,4,2,0,1,8,0},
                {0,0,0,7,0,5,0,2,6},
                {1,0,0,9,0,4,0,0,0},
                {0,5,0,0,0,0,0,4,0},
                {0,0,0,5,0,7,0,0,9},
                {9,2,0,1,0,8,0,0,0},
                {0,3,4,0,5,9,0,0,0},
                {5,0,7,0,0,0,0,0,0}
            });

            inputs.Add(3, new[,] {
                { 0,0,3,0,2,0,6,0,0},
                { 9,0,0,3,0,5,0,0,1},
                { 0,0,1,8,0,6,4,0,0},
                { 0,0,8,1,0,2,9,0,0},
                { 7,0,0,0,0,0,0,0,8},
                { 0,0,6,7,0,8,2,0,0},
                { 0,0,2,6,0,9,5,0,0},
                { 8,0,0,2,0,3,0,0,9},
                { 0,0,5,0,1,0,3,0,0}
            });

            foreach(var input in inputs)
            {
                for (int r = 0; r < 8; r++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        Console.WriteLine("defaultPuzzles.Add(new Puzzle {{ puzzleId = {0}, row = {1}, col = {2}, value = {3} }});", input.Key, r, c, input.Value[r, c]);
                    }
                }
            }
            
        }
    }
}
