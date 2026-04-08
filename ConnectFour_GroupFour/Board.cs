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
