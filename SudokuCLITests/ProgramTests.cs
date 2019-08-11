using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void getColFirstEmptyCellTest()
        {
            int[,] smallBoard = new int[,]
            {
                {2, 0, 3},
                {1, 0, 0},
                { 0, 0, 1}
            };


            Assert.Fail();
        }
    }
}