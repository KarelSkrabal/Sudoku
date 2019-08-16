using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuUI
{
    public class Puzzle
    {

        public int iD { get; set; }

        public int puzzleId { get; set; }
        
        public int row { get; set; }
        
        public int col { get; set; }
        
        public int value { get; set; }

    }
}
