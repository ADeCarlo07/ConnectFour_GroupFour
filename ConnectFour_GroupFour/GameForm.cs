using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_GroupFour
{
    public partial class GameForm : Form
    {
        StartForm sform;
        private Board gameBoard;
        public GameForm()
        {
            InitializeComponent();
            gameBoard = new Board();
            InitializeBoard();

            //Form is loaded to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            //Below if we want to manual position the form to the top left as the directions mentioned
            //this.StartPosition = FormStartPosition.Manual;
            //this.Top = 0;
            //this.RightToLeft = 0;
        }

        public GameForm(StartForm sf)
        {
            InitializeComponent();

            //added because error kept displaying saying gameBoard was null
            gameBoard = new Board();
            InitializeBoard();

            //global variable of the start form so it can be referenced
            sform = sf;
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
        private async void CellButtonPressed(object sender, EventArgs e)
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

                    //this is just for testing purposes, when game is more fleshed out there
                    //will be more checks involved before placing a piece
                    //GC: added a visual so we can tell at a glance when a piece occupies a cell, images to be added later
                    if (!c.GetCellContainPiece())
                    {
                        //make sure there is something bellow the piece if they are placing mid-air
                        if (c.GetRow() != 5)
                        {
                            //for testing purposes
                            Console.WriteLine("Player attempted to place piece above row 5");

                            if (!gameBoard.GetCellBelow(c.GetRow(), c.GetCol()).GetCellContainPiece())
                            {
                                //if this if statement is triggered then it means there is no piece below
                                //the cell that was clicked

                                //the col doesn't matter since it will stay the same as original cell clicked
                                int rowBelowCurCell = gameBoard.GetCellBelow(c.GetRow(), c.GetCol()).GetRow();

                                //this loop will go through every row until it reaches row 5
                                //if it finds a cell with a piece below it, it is safe to place
                                //if it reaches row 5, it is safe to place
                                for (int i = 0; i < 5; i++)
                                {
                                    int r = rowBelowCurCell + i;

                                    //**this will have to be edited and revised as we make more logic
                                    //to the game. For now its purpose is to be like a falling
                                    //"animation" without really being an animation
                                    if (i == 0)
                                    {
                                        //I had trouble with getting the cell that was clicked to be
                                        //red so I went with this sloppy solution, don't judge too hard
                                        c.GetButton().BackColor = Color.Red;
                                        await Task.Delay(300);
                                        c.GetButton().BackColor = Color.White;

                                    }

                                    if (r - 1 > c.GetRow())
                                    {
                                        Cell prevCell = gameBoard.GetCell(r - 1, c.GetCol());
                                        prevCell.GetButton().BackColor = Color.White;
                                    }

                                    Cell cell = gameBoard.GetCell(r, c.GetCol());
                                    cell.GetButton().BackColor = Color.Red;

                                    await Task.Delay(300);

                                    //end of animation code

                                    if (r == 5 || gameBoard.GetCellBelow(r, c.GetCol()).GetCellContainPiece())
                                    {
                                        //they reached the bottom without finding a cell that contains a piece
                                        Console.WriteLine("Safe cell found, ROW: " + r + "   COL: " + c.GetCol());

                                        //place piece, it wont be mid-air
                                        //testing: when button is pressed for the first time, sets contains piece to true and changes back color to red
                                        Cell safeCell = gameBoard.GetCell(r, c.GetCol());

                                        safeCell.SetCellContainsPiece(true);
                                        safeCell.GetButton().BackColor = Color.Red;

                                        //break out of loop, could be removed later I just don't want it to keep
                                        //going on if it doesn't have to
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //testing: when button is pressed for the first time, sets contains piece to true and changes back color to red
                                c.SetCellContainsPiece(true);
                                button.BackColor = Color.Red;
                            }
                           
                        }
                        else
                        {
                            //place piece, it wont be mid-air
                            //testing: when button is pressed for the first time, sets contains piece to true and changes back color to red
                            c.SetCellContainsPiece(true);
                            button.BackColor = Color.Red;
                        }


                    }
                    else
                    {
                        //testing: when button is pressed for the second time, sets contains piece to false and changes back to white
                        c.SetCellContainsPiece(false);
                        button.BackColor = Color.White;
                    }
                }
            }
        }
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //calls the close form function to close the application
            sform.closeForms();
        }
    }
}
