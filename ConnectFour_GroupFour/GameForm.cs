using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        int currentPlayer = 1; //player 1 starts(red)
        int gameMode; //1 = single player, 2 = 2 players
        public GameForm()
        {
            InitializeComponent();
            gameBoard = new Board();
            InitializeBoard();

            UpdateTurnLabel();

            //Form is loaded to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            //Below if we want to manual position the form to the top left as the directions mentioned
            //this.StartPosition = FormStartPosition.Manual;
            //this.Top = 0;
            //this.RightToLeft = 0;


   
        }

        public GameForm(StartForm sf, int mode)
        {
            InitializeComponent();

            //added because error kept displaying saying gameBoard was null
            gameBoard = new Board();
            InitializeBoard();

            //global variable of the start form so it can be referenced
            sform = sf;
            gameMode = mode;
        }


        //so we can read info from the text file to properly update it
        private int[] ReadFromTextFile()
        {
            int[] vals = new int[4];
            try
            {
                String[] lines = File.ReadAllLines(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt");
                List<String> l = lines.ToList();

                try
                {
                    foreach (String line in l)
                    {
                        if (line == "")
                        {
                            l.Remove(line);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR! Txt file has a manual error of two empty lines.");
                }

                foreach (String line in l)
                {
                    Console.WriteLine(line);
                }

                vals[0] = int.Parse(l[0]);
                vals[1] = int.Parse(l[1]);
                vals[2] = int.Parse(l[2]);
                vals[3] = int.Parse(l[0]) + int.Parse(l[1]) + int.Parse(l[2]);

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return vals;
        }

        //for when we need to update info in stats file
        //how to call:
        //if gameState == 1 then AI won
        //if gameState == 2 then Player won
        //if gameState == 0 then it was a draw
        private void UpdateTextFile(int gameState)
        {
            int[] vals = ReadFromTextFile();
            String[] lines = File.ReadAllLines(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt");
            List<String> l = lines.ToList();
            String text = "";


            foreach (String line in l)
            {
                if (line == "")
                {
                    l.Remove(line);
                }
            }

            if (gameState == 1)
            {
                int updatedAIWins = vals[0] + 1;
                Console.WriteLine("Updated AI wins: " + updatedAIWins);
                l[0] = updatedAIWins.ToString();
                l[1] = vals[1].ToString();
                l[2] = vals[2].ToString();
            }
            else if (gameState == 2)
            {
                int updatedPlayerWins = vals[1] + 1;
                Console.WriteLine("Updated Player wins: " + updatedPlayerWins);
                l[0] = vals[0].ToString();
                l[1] = updatedPlayerWins.ToString();
                l[2] = vals[2].ToString();
            }
            else if (gameState == 0)
            {
                int updatedDraws = vals[2] + 1;
                Console.WriteLine("Updated draws: " + updatedDraws);
                l[0] = vals[0].ToString();
                l[1] = vals[1].ToString();
                l[2] = updatedDraws.ToString();
            }

            for (int i = 0; i < l.Count; i++)
            {
                text += l[i] + "\n";
            }

            //test
            Console.WriteLine(text);

            //overwrite text file
            File.WriteAllText(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt", text);

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
                    //added a visual so we can tell at a glance when a piece occupies a cell, images to be added later
                    if (!c.GetCellContainPiece())
                    {
                        //If cell does not contain a piece
                        gameBoard.addPiece(c.GetCol(), currentPlayer);
                        //switches between player turns after placing a piece
                        if(currentPlayer == 1)
                        {
                            currentPlayer = 2;
                        }
                        else
                        {
                            currentPlayer = 1;
                        }
                        //FOR AI LOGIC:
                        //it would look something like this
                        //if(gameMode == 1 && currentPlayer == 2)
                        //{
                        ////ai algorithm
                        //}
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
        //show player move when the mouse hovers over a cell
        private void CellButtonHover(object sender, EventArgs e)
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
                    Console.WriteLine("HOVER -  ROW: " + c.GetRow() + "    COL: " + c.GetCol());

                    if (!c.GetCellContainPiece())
                    {
                        //If cell does not contain a piece
                        gameBoard.showMove(c.GetCol(), currentPlayer, hover);
                    }
                }
            }
        }
        //reset cell color when mouse is no longer hovering
        private void CellButtonLeave(object sender, EventArgs e)
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
                    Console.WriteLine("LEAVE - ROW: " + c.GetRow() + "    COL: " + c.GetCol());
                    gameBoard.showMove(c.GetCol(), currentPlayer, hover);
                }
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //calls the close form function to close the application
            sform.closeForms();
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
                if(currentPlayer == 1)
                {
                    lbl_turn.Text = "Player 1's Turn";
                }
                else
                {
                    lbl_turn.Text = "Computer's Turn";
                }
            }
        }

        public int getGameMode(int gameMode)
        {// 1 = vs AI, 2 = 2p
            return gameMode;
        }
    }
}