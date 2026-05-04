//==========================================================
//Name: Allison DeCarlo, Giovanni Cuadra, Layla Kleinow,
//      Julian Miles, Elijah Wright
//Date: 05/10/2026
//Desc: Connect Four Group Project
//==========================================================


using ConnectFour_GroupFour.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_GroupFour
{
    public partial class GameForm : Form
    {
        StartForm startForm;
        StatsForm statsForm;
        private Board gameBoard;
        int currentPlayer = 1; //player 1 starts(red)
        int gameMode; //1 = single player, 2 = 2 players
        bool gameOver = false;
        int modeType;
        SoundPlayer sound_hover = new SoundPlayer(Properties.Resources.c4hoverover2);
        SoundPlayer sound_select = new SoundPlayer(Properties.Resources.c4select2);
        SoundPlayer sound_place = new SoundPlayer(Properties.Resources.c4place);
        SoundPlayer sound_win = new SoundPlayer(Properties.Resources.c4win);

        public GameForm()
        {
            InitializeComponent();
        }

        //realized that only this overloaded constructor was being called when this form loads
        public GameForm(StartForm sf, int mode)
        {
            modeType = mode;
            InitializeComponent();
            //hover over buttons 
            btn_game_returnToStat.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };
            btn_exit.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };
            btn_menu.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };

            //added because error kept displaying saying gameBoard was null
            gameBoard = new Board();
            InitializeBoard();
            UpdateTurnLabel();

            //global variable of the start form so it can be referenced
            startForm = sf;
            gameMode = mode;
            if (gameMode == 1)
                gameBoard.setAIActive(true);
            else 
                gameBoard.setAIActive(false);
        }

        public int GetGameMode()
        {
            return gameMode;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //calls the close form function to close the application
            startForm.closeAll();
        }

        private void exitProgram(object sender, EventArgs e)
        {
            sound_select.Play();

            startForm.closeAll();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            sound_select.Play();

            if (!gameOver)
            {
                startForm.Show();
                this.Hide();
            }
        }

        private void InitializeBoard()
        {
            string name;
            char delim = '_';
            int posDelim;
            int col;
            int row;
            Cell c;

            foreach (Button b in this.Controls.OfType<Button>())
            {
                //like in professors example, each cell name is in a pattern (cell_row_col) so I can
                //evaluate where it needs to go in board 2D array from there

                //make sure we are only looking at buttons whose name has cell in it
                if (b.Name.Contains("cell"))
                {
                    //this is pretty much a copy/paste from helper
                    name = b.Name;

                    Console.WriteLine("Cell name to be added: " + name);

                    posDelim = name.IndexOf(delim);
                    //Look one place past where we found the delim and then read one character, that is the row

                    //Important note from prof:
                    //**If this was a two digit by two digit grid (10x10, 15x30, etc.) this would break.
                    row = Int32.Parse(name.Substring(posDelim + 1, 1));

                    Console.WriteLine("row: " + row.ToString());

                    //name is now only equal to everything after the row number we found
                    name = name.Substring(posDelim + 2);

                    //Find the delim again
                    posDelim = name.IndexOf(delim);
                    col = Int32.Parse(name.Substring(posDelim + 1));

                    Console.WriteLine("col: " + col.ToString());
                    Console.WriteLine("button: " + b.Name);

                    //create a new cell
                    c = new Cell(row, col, b);

                    //in beg of game no cells contain pieces
                    c.SetCellContainsPiece(false);

                    //add that cell to the gameboard
                    gameBoard.SetGameBoardCell(c);
                }
            }
        }

        //async allows for use of delays
        private void CellButtonPressed(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                //get the button pressed
                Button button = (Button)sender;

                //get the board
                Cell[,] board = gameBoard.GetGameBoard();

                //cycle through each cell in the board and write the row and col in console as a test
                foreach (Cell c in board)
                {
                    Button boardButton = c.GetButton();

                    if (boardButton.Name == button.Name)
                    {
                        Console.WriteLine("ROW: " + c.GetRow() + "    COL: " + c.GetCol());

                        if (!c.GetCellContainPiece())
                        {
                            //If cell does not contain a piece
                            if (gameMode == 1)//if single player its only ever adding red
                                gameBoard.addPiece(c.GetCol(), 1);
                            else
                                gameBoard.addPiece(c.GetCol(), currentPlayer);
                            //check for win
                            int winner = gameBoard.CheckWin();

                            if (winner != 0)
                            {
                                //sound_win.Play();

                                if (winner == 2 && gameMode == 1)
                                {
                                    EndGame(winner + 1);
                                }
                                else
                                {
                                    EndGame(winner);
                                }
                                return;
                            }
                            //check for draw
                            if (gameBoard.CheckDraw())
                            {
                                //sound_win.Play();

                                EndGame(0);
                                return;
                            }
                            //AI MOVE
                            if (gameMode == 1)
                            {
                                gameBoard.MakeAIMove(gameOver); //this replaces the old scanBoard trigger
                                sound_place.Play();
                            }
                            //check for win again
                            winner = gameBoard.CheckWin();
                            if (winner != 0)
                            {
                                //sound_win.Play();

                                if (winner == 2)
                                {
                                    EndGame(3);
                                }
                                else
                                {
                                    EndGame(winner);
                                }
                                    return;
                            }
                            //check for draw again
                            if (gameBoard.CheckDraw())
                            {
                                //sound_win.Play();

                                EndGame(0);
                                return;
                            }
                            //switches between player turns after placing a piece
                            if (gameMode == 2)
                            {
                                if (currentPlayer == 1)
                                {
                                    currentPlayer = 2;
                                }
                                else
                                {
                                    currentPlayer = 1;
                                }
                            }

                            UpdateTurnLabel();
                        }
                        else
                        {
                            //testing: when button is pressed for the second time, sets contains piece to false and changes back to white

                            //commented this out, removing tiles is not currently updated in the boards height array
                            //c.SetCellContainsPiece(false);
                            //button.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        //show player move when the mouse hovers over a cell
        private void CellButtonHover(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                Button button = (Button)sender;
                bool hover = true;

                //get the board
                Cell[,] board = gameBoard.GetGameBoard();

                //cycle through each cell in the board and write the row and col in console as a test
                foreach (Cell c in board)
                {
                    Button boardButton = c.GetButton();

                    if (boardButton.Name == button.Name)
                    {
                        //Console.WriteLine("HOVER -  ROW: " + c.GetRow() + "    COL: " + c.GetCol());

                        if (!c.GetCellContainPiece())
                        {
                            if (gameMode == 1)//single player only hovers red
                            {
                                gameBoard.showMove(c.GetCol(), 1, hover);
                            }//If cell does not contain a piece
                            else
                            {
                                gameBoard.showMove(c.GetCol(), currentPlayer, hover);
                            }
                        }
                    }
                }
            }
        }
        //reset cell color when mouse is no longer hovering
        private void CellButtonLeave(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                Button button = (Button)sender;
                bool hover = false;

                //get the board
                Cell[,] board = gameBoard.GetGameBoard();

                //cycle through each cell in the board and write the row and col in console as a test
                foreach (Cell c in board)
                {
                    Button boardButton = c.GetButton();

                    if (boardButton.Name == button.Name)
                    {
                        //Console.WriteLine("LEAVE - ROW: " + c.GetRow() + "    COL: " + c.GetCol());
                        gameBoard.showMove(c.GetCol(), currentPlayer, hover);
                    }
                }
            }
            
        }

        //explicitly states whose turn it is and changes once a piece is added
        private void UpdateTurnLabel()
        {
            if (gameMode == 2)
            {
                if (currentPlayer == 1)
                {
                    lbl_turn.Text = "Player 1's Turn";
                }
                else
                {
                    lbl_turn.Text = "Player 2's Turn";
                }
            }
            else
            {
                if (currentPlayer == 1)
                {
                    lbl_turn.Text = "Player 1's Turn";
                }
                else
                {
                    lbl_turn.Text = "Computer's Turn";
                }
            }
        }

        private void EndGame(int winner)
        {
            sound_win.Play();

            gameBoard.SetGameOver(true);
            //winner meanings: 0 = draw, 1 = player 1, 2 = player 2/ AI
            Console.WriteLine("Game Over. Winner = " + winner);
            //update stats file
            //UpdateTextFile(winner);
            //winner screen

            btn_menu.Visible = false;
            btn_game_returnToStat.Visible = true;

            StatsForm sf = new StatsForm(startForm, this, winner);
            statsForm = sf;
            sf.Show();

            gameOver = true;
            this.Hide();

            return;
        }

        private void AfterGameTest_Click(object sender, EventArgs e)
        {
            //StatsForm sf = new StatsForm(startForm, this);

            //sf.Show();
            //this.Hide();
        }

        private void btn_game_returnToStat_Click(object sender, EventArgs e)
        {
            sound_select.Play();

            statsForm.Show();
            this.Hide();
        }
    }
}