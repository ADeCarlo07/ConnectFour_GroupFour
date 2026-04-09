using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_GroupFour
{
    internal class Board
    {
        private const int numRows = 6;
        private const int numCols = 7;
        Cell[,] gameBoard = new Cell[numRows, numCols];

        public int GetNumRows()
        {
            return numRows;
        }
        public int GetNumCols()
        {
            return numCols;
        }

        public Cell GetCell(int r, int c)
        {
            return gameBoard[r, c];
        }

        //Could be changed/removed. Just thought they would be helpful when
        //checking for things on the board
        public Cell GetCellBelow(int r, int c)
        {
            return gameBoard[r + 1, c];
        }

        public Cell GetCellToRight(int r, int c)
        {
            return gameBoard[r, c + 1];
        }

        public Cell GetCellToLeft(int r, int c)
        {
            return gameBoard[r, c - 1];
        }

        public Cell GetCellAbove(int r, int c)
        {
            return gameBoard[r - 1, c];
        }

        public Cell GetCellDiagonalUpperRight(int r, int c)
        {
            return gameBoard[r - 1, c + 1];
        }

        public Cell GetCellDiagonalUpperLeft(int r, int c)
        {
            return gameBoard[r - 1, c - 1];
        }

        public Cell GetCellDiagonalLowerRight(int r, int c)
        {
            return gameBoard[r + 1, c + 1];
        }

        public Cell GetDiagonalLowerLeft(int r, int c)
        {
            return gameBoard[r + 1, c - 1];
        }

        public Cell[,] GetGameBoard()
        {
            return gameBoard;
        }

        public void SetGameBoardCell(Cell cell)
        {
            //the only reason I can do this is because I am going to make sure that I 
            //set the row and col of a cell before I add it to the board
            gameBoard[cell.GetRow(), cell.GetCol()] = cell;
        }


    }
}
