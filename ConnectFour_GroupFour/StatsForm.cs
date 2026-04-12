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
    public partial class StatsForm : Form
    {
        private StartForm startForm;
        private int aiWins;
        private int playerWins;
        private int draws;
        private int totalGames;

        public StatsForm()
        {
            InitializeComponent();
            InitDummyData();
        }

        public StatsForm(StartForm sf)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            startForm = sf;

            InitDummyData();
            ReadFromTextFile();
            InitChart();

            UpdateLabels();
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
                StreamReader reader = new StreamReader(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt");

                //read stream
                String text = reader.ReadToEnd();
                reader.Close();

                if (text == "")
                {
                    Console.WriteLine("File Is Empty");

                    //AI wins
                    String aiWins = "8";

                    //Player wins
                    String playerWins = "5";

                    //Draws
                    String draws = "7";

                    //Total games
                    //String totalGames = "20";

                    StreamWriter writer = new StreamWriter(@"C:\Users\allis\OneDrive\Desktop\CIS153\Homework\ConnectFour_GroupFour\ConnectFour_GroupFour\Stats.txt");

                    writer.WriteLine(aiWins);
                    writer.WriteLine(playerWins);
                    writer.WriteLine(draws);
                    //writer.WriteLine(totalGames);

                    writer.Close();

                }
                else
                {
                    //test
                    Console.WriteLine(text);
                }



            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        

        private void ReadFromTextFile()
        {
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

                aiWins = int.Parse(l[0]);
                playerWins = int.Parse(l[1]);
                draws = int.Parse(l[2]);
                totalGames = int.Parse(l[0]) + int.Parse(l[1]) + int.Parse(l[2]);

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
            chart_stats_gameStats.Series["Games"].Points.AddXY("Player", playerWins);
            chart_stats_gameStats.Series["Games"].Points.AddXY("Draw", draws);

            chart_stats_gameStats.Series["Games"].Points[0].Color = Color.FromArgb(200, 255, 255, 0);
            chart_stats_gameStats.Series["Games"].Points[1].Color = Color.FromArgb(200, 255, 0, 0);
            chart_stats_gameStats.Series["Games"].Points[2].Color = Color.FromArgb(200, 255, 165, 0);


        }

        private void UpdateLabels()
        {
            double aiWinPerc = ((double)aiWins / (double)totalGames) * 100;
            double playerWinPerc = ((double)playerWins / (double)totalGames) * 100;

            lbl_stats_aiWinPerc.Text = aiWinPerc + "%";
            lbl_stats_playerWinPerc.Text = playerWinPerc + "%";
            lbl_stats_totalGames.Text = totalGames.ToString();

        }
    }
}
