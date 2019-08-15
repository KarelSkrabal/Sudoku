using SudokuSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SudokuSolver.Tests
{
    [TestClass()]
    public class SudokuTests
    {
        int[,] board = new int[,]{
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}};

        int[,] smallBoard = new int[,]{
                {2, 3, 0},
                {1, 0, 0},
                { 0, 0, 1}};

        Sudoku sudoku = new SudokuSolver.Sudoku();

        [TestMethod()]
        public void isValidSubgripValueTest_returns_FALSE()
        {
            int[] testValues = new int[] { 2, 5, 7, 4, 3 };

            foreach (var value in testValues)
            {
                Assert.IsFalse(sudoku.isValidSubgridValue(board, 8, 7, value));
            }
        }

        [TestMethod()]
        public void isValidSubgripValueTest_returns_TRUE()
        {
            int[] testValues = new int[] { 1, 6, 8, 9 };

            foreach (var value in testValues)
            {
                Assert.IsTrue(sudoku.isValidSubgridValue(board, 8, 8, value));
            }
        }

        [TestMethod()]
        public void isValidRowTest_returns_FALSE()
        {
            Assert.IsFalse(sudoku.isValidRow(board, 0, 1, 3));
        }

        [TestMethod()]
        public void isValidRowTest_returns_TRUE()
        {
            Assert.IsTrue(sudoku.isValidRow(board, 0, 1, 1));
        }

        [TestMethod()]
        public void isValidColTest_returns_FALSE()
        {
            Assert.IsFalse(sudoku.isValidCol(board, 8, 1, 3));
        }

        [TestMethod()]
        public void isValidColTest_returns_TRUE()
        {
            Assert.IsTrue(sudoku.isValidCol(board, 8, 1, 1));
        }

        [TestMethod()]
        public void getUpperBoundTest_returns_2_TRUE()
        {
            int[] possibleValues = new int[] { 0, 1, 2};
            foreach(var possibleValue in possibleValues)
            {
                Assert.AreEqual(2, sudoku.getUpperBound(possibleValue));
            }            
        }
        [TestMethod]
        public void getUpperBoundTest_returns_5_TRUE()
        {
            int[] possibleValues = new int[] { 3, 4, 5 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreEqual(5, sudoku.getUpperBound(possibleValue));
            }
        }
        [TestMethod]
        public void getUpperBoundTest_returns_8_TRUE()
        {
            int[] possibleValues = new int[] { 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreEqual(8, sudoku.getUpperBound(possibleValue));
            }
        }

        [TestMethod()]
        public void getUpperBoundTest_not_returns_2()
        {
            int[] possibleValues = new int[] { 3, 4, 5 , 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(2, sudoku.getUpperBound(possibleValue));
            }
        }
        [TestMethod()]
        public void getUpperBoundTest_not_returns_5()
        {
            int[] possibleValues = new int[] { 0,1,2, 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(5, sudoku.getUpperBound(possibleValue));
            }
        }
        [TestMethod()]
        public void getUpperBoundTest_not_returns_8()
        {
            int[] possibleValues = new int[] {0,1,2, 3, 4, 5 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(8, sudoku.getUpperBound(possibleValue));
            }
        }

        [TestMethod()]
        public void getLowerBoundTest_returns_2_TRUE()
        {
            int[] possibleValues = new int[] { 0, 1, 2 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreEqual(0, sudoku.getLowerBound(possibleValue));
            }
        }
        [TestMethod]
        public void getLowerBoundTest_returns_5_TRUE()
        {
            int[] possibleValues = new int[] { 3, 4, 5 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreEqual(3, sudoku.getLowerBound(possibleValue));
            }
        }
        [TestMethod]
        public void getLowerBoundTest_returns_8_TRUE()
        {
            int[] possibleValues = new int[] { 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreEqual(6, sudoku.getLowerBound(possibleValue));
            }
        }

        [TestMethod()]
        public void getLowerBoundTest_not_returns_2()
        {
            int[] possibleValues = new int[] { 3, 4, 5, 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(2, sudoku.getLowerBound(possibleValue));
            }
        }
        [TestMethod()]
        public void getLowerBoundTest_not_returns_5()
        {
            int[] possibleValues = new int[] { 0, 1, 2, 6, 7, 8 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(5, sudoku.getLowerBound(possibleValue));
            }
        }
        [TestMethod()]
        public void getLowerBoundTest_not_returns_8()
        {
            int[] possibleValues = new int[] { 0, 1, 2, 3, 4, 5 };
            foreach (var possibleValue in possibleValues)
            {
                Assert.AreNotEqual(8, sudoku.getLowerBound(possibleValue));
            }
        }
    }
}