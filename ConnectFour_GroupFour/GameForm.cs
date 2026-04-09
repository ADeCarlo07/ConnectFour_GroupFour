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

        private void CellButtonPressed(object sender, EventArgs e)
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
                        //testing: when button is pressed for the first time, sets contains piece to true and changes back color to red
                        c.SetCellContainsPiece(true);
                        button.BackColor = Color.Red;
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
