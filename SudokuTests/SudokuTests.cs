﻿using SudokuSolver;
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
            int[] testValues = new int[] { 2,5,7,4,3 };

            foreach(var value in testValues)
            {
                Assert.IsFalse(sudoku.isValidSubgridValue(board, Convert.ToInt16(System.Math.Sqrt(board.Length)), 8, 7, value));
            }            
        }

        [TestMethod()]
        public void isValidSubgripValueTest_returns_TRUE()
        {
            int[] testValues = new int[] { 1, 6,8,9};

            foreach (var value in testValues)
            {
                Assert.IsTrue(sudoku.isValidSubgridValue(board, Convert.ToInt16(System.Math.Sqrt(board.Length)), 8, 8, value));
            }
        }

        [TestMethod()]
        public void isValidRowTest_returns_FALSE()
        {
            Assert.IsFalse(sudoku.isValidRow(board, 9, 0, 1, 3));
        }

        [TestMethod()]
        public void isValidRowTest_returns_TRUE()
        {
            Assert.IsTrue(sudoku.isValidRow(board, 9, 0, 1, 1));
        }

        [TestMethod()]
        public void isValidColTest_returns_FALSE()
        {
            Assert.IsFalse(sudoku.isValidCol(board, 9, 8, 1, 3));
        }

        [TestMethod()]
        public void isValidColTest_returns_TRUE()
        {
            Assert.IsTrue(sudoku.isValidCol(board, 9, 8, 1, 1));
        }
        [TestMethod()]
        public void getColFirstEmptyCellTest()
        {
            Assert.AreEqual(2, sudoku.getColFirstEmptyCell(smallBoard, 3));
        }

        [TestMethod()]
        public void getRowFirstEmptyCellTest()
        {
            Assert.AreEqual(2, sudoku.getColFirstEmptyCell(smallBoard, 3));
        }
    }
}