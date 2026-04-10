using System;
using System.Collections.Generic;
using System.Drawing;
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
        int[] ColHeight = {5,5,5,5,5,5,5};//how many pieces are in each col The Bottom is row 5, so -1 every time a piece is added

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

        public int GetColHeight(int i)
        {
            return ColHeight[i];
        }

        public void addPiece(int col)// adds a cell to the given Col
        {
            
            if (ColHeight[col] >= 0)//safety check, make sure we are not in a negative col
            {
                Console.WriteLine("PLACING IN COL: " + col);
                //at the height of the col in the col
                gameBoard[ColHeight[col], col].SetCellContainsPiece(true);//make the cell contain a piece
                gameBoard[ColHeight[col], col].GetButton().BackColor = Color.Red;

                ColHeight[col]--;//tell the board the height change
            }
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
