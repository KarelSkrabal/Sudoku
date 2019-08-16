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
        [Key]
        public int puzzleId { get; set; }
        [Required]
        
        public string cell { get; set; }
        public int value { get; set; }

    }
}
