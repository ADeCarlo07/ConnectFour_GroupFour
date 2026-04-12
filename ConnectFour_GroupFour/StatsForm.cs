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
        public StatsForm(StartForm sf, GameForm gf)  //if stats was entered automatically after a game
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

            UpdateLabels();
            WinText.Visible = true;
            WinText.Text = "You win!!!"; //doesnt tell you the winner yet
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
            //line 1 is ai wins
            //line 2 is player wins
            //line 3 is total draws
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
                    aiWins = 8;
                    player1Wins = 5;
                    player2Wins = 2;
                    draws = 7;
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
                        writer.WriteLine(aiWins.ToString());
                        writer.WriteLine(player1Wins.ToString());
                        writer.WriteLine(player2Wins.ToString());
                        writer.WriteLine(totalGames.ToString());
                    }


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
                    Console.WriteLine("After Changes: ");
                    //UpdateStats(0);
                    ReadFromTextFile();
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

            //draws
            if (winner == 0)
            {
                draws += 1;
            }
            //ai wins
            if (winner == 1)
            {
                aiWins += 1;
            }
            //player 1 wins
            if (winner == 2)
            {
                player1Wins += 1;
            }
            //player 2 wins
            else
            {
                player2Wins += 1;
            }

            //the whole text file is cleared and then replaced with updated stats
            using (StreamWriter writer = file)
            {
                writer.WriteLine(draws.ToString());
                writer.WriteLine(aiWins.ToString());
                writer.WriteLine(player1Wins.ToString());
                writer.WriteLine(player2Wins.ToString());
                writer.WriteLine(totalGames.ToString());
            }
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

                draws = int.Parse(l[0]);
                aiWins = int.Parse(l[1]);
                player1Wins = int.Parse(l[2]);
                player2Wins = int.Parse(l[3]);
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

            //updated percentage displays
            lbl_stats_aiWinPerc.Text = aiWinPerc.ToString("0.00") + "%";
            lbl_stats_player1WinPerc.Text = player1WinPerc.ToString("0.00") + "%";
            lbl_stats_player2WinPerc.Text = player2WinPerc.ToString("0.00") + "%";
            lbl_stats_totalGames.Text = totalGames.ToString();
        }
        //play again, only accessible after a game
        private void PlayAgainButton_Click(object sender, EventArgs e) 
        {
            this.Hide();
            startForm.loadBoard(1);
        }
        //review, only accessible after a game. only sends you back to the game for now
        private void ReviewButton_Click(object sender, EventArgs e) 
        {
            this.Hide();
            startForm.loadBoard(1);
        }
    }
}
