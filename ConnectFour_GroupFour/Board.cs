using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void addPiece(int col, int player)// adds a cell to the given Col
        {
            
            if (ColHeight[col] >= 0)//safety check, make sure we are not in a negative col
            {
                Console.WriteLine("PLACING IN COL: " + col);
                //at the height of the col in the col
                gameBoard[ColHeight[col], col].SetCellContainsPiece(true);//make the cell contain a piece
                //changes colors now, no longer just red
                if(player == 1)
                {
                    gameBoard[ColHeight[col], col].GetButton().BackColor = Color.Red;
                    gameBoard[ColHeight[col], col].SetPieceColor(1);
                    ColHeight[col]--;//tell the board the height change
                    scanBoard();//scan the new board for the ai's turn
                }
                else
                {
                    gameBoard[ColHeight[col], col].GetButton().BackColor = Color.Yellow;
                    gameBoard[ColHeight[col], col].SetPieceColor(2);
                    ColHeight[col]--;//tell the board the height change
                }
            }
        }
        //shows the players move
        public void showMove(int col, int player, bool hover)
        {
            if (ColHeight[col] >= 0)
            {
                //once mouse is no longer hovering over the button, changes color back to default
                if (!hover)
                {
                    gameBoard[ColHeight[col], col].GetButton().BackColor = Color.White;
                }
                //when mouse goes over a cell, changes color to indicate move placement
                else
                {
                    if (player == 1)
                    {
                        gameBoard[ColHeight[col], col].GetButton().BackColor = Color.Pink;
                    }
                    else
                    {
                        gameBoard[ColHeight[col], col].GetButton().BackColor = Color.LightYellow;
                    }
                }
            }
        }

        // Enemy Ai Things ==================================================================================================================================
        // ==================================================================================================================================
        // ==================================================================================================================================
        private void scanBoard()
        {
            int[,] pieceConnectionScore =  { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
            int[,] pieceBlockScore = { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
            int[,] pieceDangerScore = { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
            //////////////////////// 4 by 7
            // Scanner Loops
            //
            
            for (int i = 0; i < 7; i++)
            {// CONNECTION SCORE
                if (ColHeight[i]+1 <= 5)
                    pieceConnectionScore[0, i] += ScanCellBelow(ColHeight[i] + 1, i, 2);
                if (i - 1 >= 0)
                    pieceConnectionScore[1, i] += ScanCellLeft(ColHeight[i], i - 1, 2);
                if (i + 1 <= 6 )
                    pieceConnectionScore[1, i] += ScanCellRight(ColHeight[i], i + 1, 2);
                if (ColHeight[i] - 1 >= 0 && i - 1 >= 0)
                    pieceConnectionScore[2, i] += ScanCellUpLeft(ColHeight[i] - 1, i - 1, 2);
                if (ColHeight[i]+1 <=5 && i+1 <= 6)
                    pieceConnectionScore[2, i] += ScanCellDownRight(ColHeight[i] + 1, i + 1, 2);
                if (ColHeight[i] + 1 <= 5 && i - 1 >= 0)
                    pieceConnectionScore[3, i] += ScanCellDownLeft(ColHeight[i] + 1, i - 1, 2); ;
                if (ColHeight[i] - 1 >=0 && i+1 <=6)
                    pieceConnectionScore[3, i] += ScanCellUpRight(ColHeight[i] - 1, i + 1, 2);
            }
            for (int i = 0; i < 7; i++)
            {// BLOCK SCORE
                if (ColHeight[i] + 1 <= 5)
                    pieceBlockScore[0, i] += ScanCellBelow(ColHeight[i] + 1, i, 1);
                if (i - 1 >= 0)
                    pieceBlockScore[1, i] += ScanCellLeft(ColHeight[i], i - 1, 1);
                if (i + 1 <= 6)
                    pieceBlockScore[1, i] += ScanCellRight(ColHeight[i], i + 1, 1);
                if (ColHeight[i] - 1 >= 0 && i - 1 >= 0)
                    pieceBlockScore[2, i] += ScanCellUpLeft(ColHeight[i] - 1, i - 1, 1);
                if (ColHeight[i] + 1 <= 5 && i + 1 <= 6)
                    pieceBlockScore[2, i] += ScanCellDownRight(ColHeight[i] + 1, i + 1, 1);
                if (ColHeight[i] + 1 <= 5 && i - 1 >= 0)
                    pieceBlockScore[3, i] += ScanCellDownLeft(ColHeight[i] + 1, i - 1, 1); ;
                if (ColHeight[i] - 1 >= 0 && i + 1 <= 6)
                    pieceBlockScore[3, i] += ScanCellUpRight(ColHeight[i] - 1, i + 1, 1);
            }
            for (int i = 0; i < 7; i++)
            {// IMMINENT DANGER SCORE
                if (ColHeight[i] + 1 <= 5)
                    pieceDangerScore[0, i] += ScanCellBelow(ColHeight[i], i, 1);
                if (i - 1 >= 0)
                    pieceDangerScore[1, i] += ScanCellLeft(ColHeight[i] -1, i - 1, 1);
                if (i + 1 <= 6)
                    pieceDangerScore[1, i] += ScanCellRight(ColHeight[i]-1, i + 1, 1);
                if (ColHeight[i] - 1 >= 0 && i - 1 >= 0)
                    pieceDangerScore[2, i] += ScanCellUpLeft(ColHeight[i] - 2, i - 1, 1);
                if (ColHeight[i] + 1 <= 5 && i + 1 <= 6)
                    pieceDangerScore[2, i] += ScanCellDownRight(ColHeight[i] , i + 1, 1);
                if (ColHeight[i] + 1 <= 5 && i - 1 >= 0)
                    pieceDangerScore[3, i] += ScanCellDownLeft(ColHeight[i], i - 1, 1); ;
                if (ColHeight[i] - 1 >= 0 && i + 1 <= 6)
                    pieceDangerScore[3, i] += ScanCellUpRight(ColHeight[i] - 2, i + 1, 1);
            }
            // debug log
            //bool wincheck = false; //for opening the stats after game //nvm
            for (int i =0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pieceConnectionScore[j, i] >= 3)
                    {
                        Console.WriteLine("I see a WIN!" + " @Col: " + i + "& Type:" + j + " score: " + pieceConnectionScore[j, i]);
                        //wincheck = true;
                    }
                    if (pieceBlockScore[j, i] >= 3)
                    {
                        Console.WriteLine("I see a BLOCK!" + " @Col: " + i + "& Type:" + j + " score: " + pieceBlockScore[j, i]);
                    }
                    if (pieceDangerScore[j, i] >= 3)
                    {
                        Console.WriteLine("I see DANGER!" + " @Col: " + i + "& Type:" + j + " score: " + pieceDangerScore[j, i]);
                    }
                }
            }
            //return wincheck;
        }
        // recursive cell scanners
        // give them a cell to start at if the cell matches its' called again, 1 = RED player 2 = YELLOW ai
        public int ScanCellBelow(int Row, int Column,  int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)//safety check, stay in the array
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)// if the color matches
            {
                return 1 + ScanCellBelow(Row+1, Column, Color);//add 1 to piece for match and check for further connections
            }
            else return 0;// no match = return 0
        }

        public int ScanCellLeft(int Row, int Column, int Color)
        {
            
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellLeft(Row, Column-1, Color);
            }
            else return 0;
        }

        public int ScanCellRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellRight(Row, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellUpRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellUpRight(Row-1, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellUpLeft(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellUpLeft(Row-1, Column-1, Color);
            }
            else return 0;
        }

        public int ScanCellDownRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellDownRight(Row+1, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellDownLeft(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
                return 0;
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellDownLeft(Row+1, Column-1, Color);
            }
            else return 0;
        }
        //==================================================================================================================================
        //==================================================================================================================================
        //==================================================================================================================================
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
