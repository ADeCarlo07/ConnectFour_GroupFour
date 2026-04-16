using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_GroupFour
{
    public partial class StatsForm : Form
    {
        private StartForm startForm;
        private GameForm gameForm;
        private int aiWins;
        private int player1Wins;
        private int player2Wins;
        private int draws;
        private int totalGames;

        public StatsForm()
        {
            InitializeComponent();
            InitDummyData();
        }

        public StatsForm(StartForm sf) //if stats was entered from the menu
        {
            InitializeComponent();
            startForm = sf;

            InitDummyData();
            ReadFromTextFile();
            InitChart();

            ReviewButton.Enabled = false;
            ReviewButton.Visible = false;
            PlayAgainButton.Enabled = false;
            PlayAgainButton.Visible = false;
            WinText.Visible = false;

            UpdateLabels();
        }

        //if gameState == 1 then AI won
        //if gameState == 2 then Player 1 won
        //if gameState == 3 then Player 2 won
        //if gameState == 0 then it was a draw
        public StatsForm(StartForm sf, GameForm gf, int winner)  //if stats was entered automatically after a game
        {
            InitializeComponent();
            startForm = sf;
            gameForm = gf;

            InitDummyData();
            ReadFromTextFile();
            InitChart();
            //review and play again buttons are only accessible after a game
            ReviewButton.Enabled = true;
            ReviewButton.Visible = true;
            PlayAgainButton.Enabled = true;
            PlayAgainButton.Visible = true;

            UpdateStats(winner);
            GraphSectionColorChanger(winner);
            WinText.Visible = true;

            if (winner == 0)
            {
                WinText.Text = "Draw Game!!!";
            }

            if (winner == 1)
            {
                WinText.Text = "Player 1 Wins!!!";
            }

            if (winner == 2)
            {
                WinText.Text = "Player 2 Wins!!!";
            }

            if (winner == 3)
            {
                WinText.Text = "AI Wins!!!";
            }


            //WinText.Text = "You win!!!"; //doesnt tell you the winner yet
            //doesnt work vvvvvvvvvv
            //int e = 1;
            //while (e < 5)
            //{
            //    e = e + 1;
            //    for (int i = 0; i < 10; i++) {
            //        Thread.Sleep(100);
            //        WinText.Font = new Font(WinText.Font.FontFamily, 12 + i);
            //    }
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(100);
            //        WinText.Font = new Font(WinText.Font.FontFamily, 22 - i);
            //    }
            //}

        }

        //this looks clunky and hard to read, but things are done in a very
        //specific order as to not mess up the order of cols on the graph.

        //- First, both series are cleared. Next, I add them in the highlight
        //series in this order: AI, Player 1, Player 2, Draw. So when you see
        //certain pieces cut and pasted in different sections its all to make
        //sure the order is maintained.

        //- There are if statements checking to make sure certain vals are not neg.
        //For example: "draw - 1". I don't know how neccesary it is because I've
        //never worked with charts on this but safety first. 
        
        //- After highlights are initialized, game series on the chart is filled out.
        //It goes in the same order (AI, Player 1, Player 2, Draw). 

        //- Lastly, if a val - 1 is 0, then we don't add the point in the games series
        //as val - 1, it would just be val with the pointer colored to green

        //all of this can be done because I changed the series chart type on both
        //game and highlight to stacked col
        private void GraphSectionColorChanger(int winner)
        {
            if (winner == 0)
            {
                //draw
                chart_stats_gameStats.Series["Games"].Points.Clear();
                chart_stats_gameStats.Series["Highlight"].Points.Clear();


                chart_stats_gameStats.Series["Highlight"].Points.AddXY("AI", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 1", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 2", 0);

                if (draws - 1 > 0)
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Draw", 1);
                    chart_stats_gameStats.Series["Highlight"].Points[3].Color = Color.FromArgb(200, 0, 255, 0);
                }
                else
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Draw", 0);
                }


                //initialize others
                chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);

                //color others
                chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);
                chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);
                chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 255, 0);

                //color previous segment of draw
                if (draws - 1 > 0)
                {
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws - 1);
                    chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 255, 165, 0);
                }
                else
                {
                    //don't want the chart to go into the negatives
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);
                    chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 0, 255, 0);
                }
                

                

            }

            if (winner == 1)
            {
                //player 1 win
                chart_stats_gameStats.Series["Games"].Points.Clear();
                chart_stats_gameStats.Series["Highlight"].Points.Clear();

                chart_stats_gameStats.Series["Highlight"].Points.AddXY("AI", 0);

                if (player1Wins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 1", 1);
                    chart_stats_gameStats.Series["Highlight"].Points[1].Color = Color.FromArgb(200, 0, 255, 0);
                }
                else
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 1", 0);
                }

                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 2", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Draw", 0);


                chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);

                //color previous segment
                if (player1Wins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins - 1);
                    chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);
                }
                else
                {
                    //don't want the chart to go into the negatives
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);
                    chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 0, 255, 0);
                }
                
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);

                chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);
                chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 255, 0);
                chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 255, 165, 0);



                
             
            }

            if (winner == 2)
            {
                //player 2 win
                chart_stats_gameStats.Series["Games"].Points.Clear();
                chart_stats_gameStats.Series["Highlight"].Points.Clear();


                chart_stats_gameStats.Series["Highlight"].Points.AddXY("AI", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 1", 0);

                if (player2Wins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 2", 1);
                    chart_stats_gameStats.Series["Highlight"].Points[2].Color = Color.FromArgb(200, 0, 255, 0);
                }
                else
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 2", 0);
                }

               
          
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Draw", 0);



                chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);

                chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);
                chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);

                //color previous segment
                if (player2Wins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins - 1);
                    chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 255, 0);
                }
                else
                {
                    //don't want the chart to go into the negatives
                    chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);
                    chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 0, 255, 0);
                }

                chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);

                chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 255, 165, 0);

                


            }

            if (winner == 3)
            {
                //ai wins
                chart_stats_gameStats.Series["Games"].Points.Clear();
                chart_stats_gameStats.Series["Highlight"].Points.Clear();

                if (aiWins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("AI", 1);
                    chart_stats_gameStats.Series["Highlight"].Points[0].Color = Color.FromArgb(200, 0, 255, 0);
                }
                else
                {
                    chart_stats_gameStats.Series["Highlight"].Points.AddXY("AI", 0);
                }

                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 1", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Player 2", 0);
                chart_stats_gameStats.Series["Highlight"].Points.AddXY("Draw", 0);



                //color previous segment
                if (aiWins - 1 > 0)
                {
                    chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins - 1);
                    chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);

                }
                else
                {
                    //don't want the chart to go into the negatives
                    chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);
                    chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 0, 255, 0);
                }
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);
                chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);


                chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);
                chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 255, 0);
                chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 255, 165, 0);


                
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            startForm.Show();
            this.Hide();
        }

        private void StatsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //calls the close form function to close the application
            startForm.closeAll();
        }

        private void exitProgram(object sender, EventArgs e)
        {
            startForm.closeAll();
        }

        //for testing purposes
        private void InitDummyData()
        {
            //line 1 is draws
            //line 2 is player1 wins
            //line 3 is total player2 wins
            //line 4 is total ai wins
            //total games is all the wins added together

            try
            {
                //open file
                //changed text file to a resource and updated the path
                StreamReader reader = new StreamReader("../../Resources/Stats.txt");

                //read stream
                String text = reader.ReadToEnd();

                reader.Close();

                if (text == "")
                {
                    Console.WriteLine("File Is Empty, added test information");

                    //variable names were declared as ints already so commented out the string redefitions
                    aiWins = 0;
                    player1Wins = 0;
                    player2Wins = 0;
                    draws = 0;
                    totalGames = aiWins + player1Wins + player2Wins + draws;

                    //AI wins
                    //String aiWins = "8";

                    //Player wins
                    //String playerWins = "5";

                    //Draws
                    //String draws = "7";

                    //Total games
                    //String totalGames = "20";

                    //StreamWriter writer = new StreamWriter(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt", false);

                    //cleaned up the streamwriter a little here
                    StreamWriter file = new StreamWriter("../../Resources/Stats.txt");

                    using (StreamWriter writer = file)
                    {
                        writer.WriteLine(draws.ToString());
                        writer.WriteLine(player1Wins.ToString());
                        writer.WriteLine(player2Wins.ToString());
                        writer.WriteLine(aiWins.ToString());
                        writer.WriteLine(totalGames.ToString());
                    }

                    file.Close();

                    //Console.WriteLine(writer.ToString());

                    //writer.WriteLine(aiWins.ToString());
                    //writer.WriteLine(playerWins.ToString());
                    //writer.WriteLine(draws.ToString());
                    //writer.WriteLine(totalGames);

                    //writer.Close();

                }
                else
                {
                    //test
                    Console.WriteLine("File Not Empty");
                    ReadFromTextFile();

                    //testing win changes
                    //Console.WriteLine("After Changes: ");
                    //UpdateStats(0);
                    //ReadFromTextFile();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        //for testing stat changes
        public void UpdateStats(int winner)
        {
            StreamWriter file = new StreamWriter("../../Resources/Stats.txt");

            Console.WriteLine("Winner: " + winner);

            //draws
            if (winner == 0)
            {
                draws += 1;
            }
            //player 1 wins
            if (winner == 1)
            {
                player1Wins += 1;
            }
            //player 2 wins
            if (winner == 2)
            {
                player2Wins += 1;
            }
            //ai wins
            else if (winner == 3)
            {
                aiWins += 1;
            }

            totalGames = aiWins + player1Wins + player2Wins + draws;

            //the whole text file is cleared and then replaced with updated stats
            using (StreamWriter writer = file)
            {
                writer.WriteLine(draws.ToString());
                writer.WriteLine(player1Wins.ToString());
                writer.WriteLine(player2Wins.ToString());
                writer.WriteLine(aiWins.ToString());
                writer.WriteLine(totalGames.ToString());
            }

            UpdateLabels();
            file.Close();
        }
        private void ReadFromTextFile()
        {
            try
            {
                ////updated paths to the resource file
                String[] lines = File.ReadAllLines("../../Resources/Stats.txt");
                List<String> l = lines.ToList();

                //different way to update the list with the read data in the text file
                Console.WriteLine(File.ReadAllLines("../../Resources/Stats.txt"));

                StreamReader file = new StreamReader("../../Resources/Stats.txt");
                String line = file.ReadLine();
                int i = 0;

                while (line != null)
                {
                    l[i] = line;
                    Console.WriteLine(line);
                    line = file.ReadLine();
                    i++;
                }

                //try
                //{
                //    foreach (String line in l)
                //    {
                //        if (line == "")
                //        {
                //            l.Remove(line);
                //        }
                //    }
                //}
                //catch
                //{
                //    Console.WriteLine("ERROR! Txt file has a manual error of two empty lines.");
                //}

                //foreach (String line in l)
                //{
                //    Console.WriteLine(line);
                //}

                file.Close();

                draws = int.Parse(l[0]);
                player1Wins = int.Parse(l[1]);
                player2Wins = int.Parse(l[2]);
                aiWins = int.Parse(l[3]);
                totalGames = int.Parse(l[4]);

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


        private void InitChart()
        {
            chart_stats_gameStats.Legends.Clear();
            chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);
            chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);
            chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);
            chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);

            chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);
            chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);
            chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 255, 0);
            chart_stats_gameStats.Series["Games"].Points[3].Color = Color.FromArgb(200, 255, 165, 0);
        }

        private void UpdateLabels()
        {
            double aiWinPerc = ((double)aiWins / (double)totalGames) * 100;
            double player1WinPerc = ((double)player1Wins / (double)totalGames) * 100;
            double player2WinPerc = ((double)player2Wins / (double)totalGames) * 100;
            double drawPerc = ((double)draws / (double)totalGames) * 100;

            //updated percentage displays
            lbl_stats_aiWinPerc.Text = aiWinPerc.ToString("0.00") + "%";
            lbl_stats_player1WinPerc.Text = player1WinPerc.ToString("0.00") + "%";
            lbl_stats_player2WinPerc.Text = player2WinPerc.ToString("0.00") + "%";
            lbl_stats_drawPerc.Text = drawPerc.ToString("0.00") + "%";
            lbl_stats_totalGames.Text = totalGames.ToString();

            //chart_stats_gameStats.Series["Games"].Points.AddXY("AI", aiWins);
            //chart_stats_gameStats.Series["Games"].Points.AddXY("Player 1", player1Wins);
            //chart_stats_gameStats.Series["Games"].Points.AddXY("Player 2", player2Wins);
            //chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);

            chart_stats_gameStats.Series["Games"].Points.Clear();

            InitChart();

        }
        //play again, only accessible after a game
        private void PlayAgainButton_Click(object sender, EventArgs e) 
        {
            this.Hide();
            gameForm.Hide();

            if (gameForm.GetGameMode() == 1)
            {
                Console.WriteLine("Reloading Single Player");
                startForm.loadBoard(1);
            }
            else
            {
                Console.WriteLine("Reloading Two Player");
                startForm.loadBoard(2);
            }
            
        }
        //review, only accessible after a game. only sends you back to the game for now
        private void ReviewButton_Click(object sender, EventArgs e) 
        {
            this.Hide();
            //startForm.loadBoard(1);

            //only exit and main menu buttons would work ideally
            gameForm.reviewBoardDisp();
            gameForm.Show();
        }

        private void btn_stats_twoPlayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            gameForm.Hide();
            startForm.loadBoard(2);
        }
    }
}