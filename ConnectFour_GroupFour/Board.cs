using ConnectFour_GroupFour.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ConnectFour_GroupFour
{
    internal class Board
    {
        private const int numRows = 6;
        private const int numCols = 7;
        Cell[,] gameBoard = new Cell[numRows, numCols];
        int[] ColHeight = {5,5,5,5,5,5,5};//how many pieces are in each col The Bottom is row 5, so -1 every time a piece is added
        bool AIenabled = false;
        private bool gameOver = false;

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
            if (gameOver)
            {
                return;
            }
            if (ColHeight[col] >= 0)//safety check, make sure we are not in a negative col
            {
                Console.WriteLine("PLACING IN COL: " + col);
                //at the height of the col in the col
                gameBoard[ColHeight[col], col].SetCellContainsPiece(true);//make the cell contain a piece
                //changes colors now, no longer just red
                if(player == 1)
                {
                    gameBoard[ColHeight[col], col].GetButton().BackgroundImage = Resources.tile_redPiece;
                    gameBoard[ColHeight[col], col].SetPieceColor(1);
                    ColHeight[col]--;//tell the board the height change  
                }
                else
                {
                    gameBoard[ColHeight[col], col].GetButton().BackgroundImage = Resources.tile_yellowPiece;
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
                    gameBoard[ColHeight[col], col].GetButton().BackgroundImage = Resources.tile_empty;
                }
                //when mouse goes over a cell, changes color to indicate move placement
                else
                {
                    if (player == 1)
                    {
                        gameBoard[ColHeight[col], col].GetButton().BackgroundImage = Resources.tile_redPieceTransparent;
                    }
                    else
                    {
                        gameBoard[ColHeight[col], col].GetButton().BackgroundImage = Resources.tile_yellowPieceTransparent;
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
            AIMakeMove(pieceConnectionScore, pieceBlockScore, pieceDangerScore);
            //return wincheck;
        }
        private void AIMakeMove(int[,] Connects, int[,] Danger, int[,] NextDanger)
        {// this is called in scanBoard
            bool[] avoidCols = { false, false, false, false, false, false, false };
            int[] totalConnectScore = { 0,0,0,0,0,0,0};
            List<int> bestIndexs = new List<int>();
            int selectedIndex = -1;
            int bestScore = int.MinValue;
            for (int i = 0; i < 7; i++)
            {

            }
            for(int i = 0; i < 7; i++)///WIN CASE
            {
                for (int j = 0; j < 4; j++)
                {
                    if(Connects[j, i] >= 3 && ColHeight[i] >= 0)
                    {
                        addPiece(i,2);//add a piece at the win spot as the AI
                        return;
                    }
                }
            }
            for (int i = 0; i < 7; i++)///BLOCK CASE
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Danger[j, i] >= 3 && ColHeight[i] >= 0)
                    {
                        addPiece(i, 2);//add a piece to block the player
                        return;
                    }
                }
            }
            for (int i = 0; i < 7; i++)///AVOID NOTES
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NextDanger[j, i] >= 3 && ColHeight[i] >= 0)
                    {
                        avoidCols[i] = true;
                    }
                }
            }
            for (int i = 0; i < 7; i++)///Evaluate Connection Score
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Connects[j,i] == 3)//prioritise longer connections over just the total number of connections
                    {
                        totalConnectScore[i] += 4;
                    }
                    else if (Connects[j, i] == 2)
                    {
                        totalConnectScore[i] += 2;
                    }
                    else if (Connects[j, i] == 1)
                    {
                        totalConnectScore[i] += 1;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (!avoidCols[i] && ColHeight[i] >= 0)
                {
                    if (totalConnectScore[i] > bestScore)
                    {
                        bestScore = totalConnectScore[i];
                        bestIndexs.Clear();/// clear all lower scores
                        bestIndexs.Add(i);// add new high score
                    }
                    else if (totalConnectScore[i] == bestScore)
                    {
                        bestIndexs.Add(i);/// tracks all indexs with equal score
                    }
                }
            }
            Random rand = new Random();
            if (bestIndexs.Count > 0)
            {

                selectedIndex = bestIndexs[rand.Next(bestIndexs.Count)];//randomly choose a col with highest score
                addPiece(selectedIndex, 2);
                return;
            }
            bestIndexs.Clear();///////// if no tile was placed the ai is assuming it will lose
            bestScore = int.MinValue;/// so we have to change it's logic to end its turn
            for (int i = 0; i < 7; i++)
            {
                if (ColHeight[i] >= 0)// same loop as above but now we ignore avoid cols
                {
                    if (totalConnectScore[i] > bestScore)///ignore the cols marked as avoid
                    {
                        bestScore = totalConnectScore[i];
                        bestIndexs.Clear();
                        bestIndexs.Add(i);
                    }
                    else if (totalConnectScore[i] == bestScore)
                    {
                        bestIndexs.Add(i);
                    }
                }
            }
            if (bestIndexs.Count > 0)
            {
                selectedIndex = bestIndexs[rand.Next(bestIndexs.Count)];
            }
            addPiece(selectedIndex, 2);
            return;
        }
        // recursive cell scanners
        // give them a cell to start at if the cell matches its' called again, 1 = RED player 2 = YELLOW ai
        public int ScanCellBelow(int Row, int Column,  int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)//safety check, stay in the array
            {
                return 0;
            }    
            if (gameBoard[Row, Column].GetPieceColor() == Color)// if the color matches
            {
                return 1 + ScanCellBelow(Row+1, Column, Color);//add 1 to piece for match and check for further connections
            }

            else return 0;// no match = return 0
        }

        public int ScanCellLeft(int Row, int Column, int Color)
        {
            
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellLeft(Row, Column-1, Color);
            }
            else return 0;
        }

        public int ScanCellRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellRight(Row, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellUpRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellUpRight(Row-1, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellUpLeft(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellUpLeft(Row-1, Column-1, Color);
            }
            else return 0;
        }

        public int ScanCellDownRight(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
            if (gameBoard[Row, Column].GetPieceColor() == Color)
            {
                return 1 + ScanCellDownRight(Row+1, Column+1, Color);
            }
            else return 0;
        }

        public int ScanCellDownLeft(int Row, int Column, int Color)
        {
            if (Row < 0 || Row > 5 || Column < 0 || Column > 6)
            {
                return 0;
            }
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
        //Checks the entire board for a winner
        //returns 0 for no winner, 1 for player 1 (red), and 2 for player 2/ AI (yellow)
        public int CheckWin()
        {
            //loop through every cell on the board
            for(int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    int player = gameBoard[r, c].GetPieceColor();

                    //skip empty cells
                    if(player == 0)
                    {
                        continue;
                    }
                    //horizontal check
                    if(c + 3 < 7 && player == gameBoard[r,c + 1].GetPieceColor() && 
                        player == gameBoard[r, c + 2].GetPieceColor() && player == gameBoard[r, c + 3].GetPieceColor())
                    {
                        Console.WriteLine("WinPlay:" + player);
                        return player;
                    }
                    //vertical check
                    if(r + 3 < 6 && player == gameBoard[r + 1, c].GetPieceColor() &&
                        player == gameBoard[r + 2, c].GetPieceColor() && player == gameBoard[r + 3, c].GetPieceColor())
                    {
                        Console.WriteLine("WinPlay:" + player);
                        return player;
                    }
                    //diagnol down right
                    if(r + 3 < 6 && c + 3 < 7 && player == gameBoard[r + 1, c + 1].GetPieceColor() &&
                        player == gameBoard[r + 2, c + 2].GetPieceColor() && player == gameBoard[r + 3, c + 3].GetPieceColor())
                    {
                        Console.WriteLine("WinPlay:" + player);
                        return player;
                    }
                    //diagnol down left
                    if(r + 3 < 6 && c - 3 >= 0 && player == gameBoard[r + 1, c - 1].GetPieceColor() &&
                        player == gameBoard[r + 2, c - 2].GetPieceColor() && player == gameBoard[r + 3, c - 3].GetPieceColor())
                    {
                        Console.WriteLine("WinPlay:" + player);
                        return player;
                    }
                }
            }
            //no winner found
            return 0;
        }
        //checks if the board is full (draw)
        public bool CheckDraw()
        {
            for(int i = 0; i < numCols; i++)
            {
                if (ColHeight[i] >= 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void setAIActive(bool state)
        {
            AIenabled = state;
        }
        public void MakeAIMove(bool gameOver)
        {
            if(gameOver)
            {
                return;
            }
            scanBoard();
        }
        public void SetGameOver(bool state)
        {
            gameOver = state;
        }
    }
}