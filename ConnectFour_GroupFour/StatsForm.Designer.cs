namespace ConnectFour_GroupFour
{
    partial class StatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_stats_gameStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_stats_totalGames = new System.Windows.Forms.Label();
            this.lbl_stats_aiWinPerc = new System.Windows.Forms.Label();
            this.lbl_stats_player2WinPerc = new System.Windows.Forms.Label();
            this.btn_menu = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_stats_player1WinPerc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ReviewButton = new System.Windows.Forms.Button();
            this.PlayAgainButton = new System.Windows.Forms.Button();
            this.WinText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stats_gameStats)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stats_gameStats
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_stats_gameStats.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_stats_gameStats.Legends.Add(legend2);
            this.chart_stats_gameStats.Location = new System.Drawing.Point(120, 63);
            this.chart_stats_gameStats.Margin = new System.Windows.Forms.Padding(2);
            this.chart_stats_gameStats.Name = "chart_stats_gameStats";
            this.chart_stats_gameStats.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Games";
            this.chart_stats_gameStats.Series.Add(series2);
            this.chart_stats_gameStats.Size = new System.Drawing.Size(479, 243);
            this.chart_stats_gameStats.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(703, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistics";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 330);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Games";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 330);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "AI Win %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(534, 330);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Player 2 Win %";
            // 
            // lbl_stats_totalGames
            // 
            this.lbl_stats_totalGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_totalGames.Location = new System.Drawing.Point(40, 364);
            this.lbl_stats_totalGames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stats_totalGames.Name = "lbl_stats_totalGames";
            this.lbl_stats_totalGames.Size = new System.Drawing.Size(125, 22);
            this.lbl_stats_totalGames.TabIndex = 5;
            this.lbl_stats_totalGames.Text = "label5";
            this.lbl_stats_totalGames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_aiWinPerc
            // 
            this.lbl_stats_aiWinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_aiWinPerc.Location = new System.Drawing.Point(210, 364);
            this.lbl_stats_aiWinPerc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stats_aiWinPerc.Name = "lbl_stats_aiWinPerc";
            this.lbl_stats_aiWinPerc.Size = new System.Drawing.Size(95, 26);
            this.lbl_stats_aiWinPerc.TabIndex = 6;
            this.lbl_stats_aiWinPerc.Text = "label5";
            this.lbl_stats_aiWinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_player2WinPerc
            // 
            this.lbl_stats_player2WinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_player2WinPerc.Location = new System.Drawing.Point(538, 364);
            this.lbl_stats_player2WinPerc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stats_player2WinPerc.Name = "lbl_stats_player2WinPerc";
            this.lbl_stats_player2WinPerc.Size = new System.Drawing.Size(134, 26);
            this.lbl_stats_player2WinPerc.TabIndex = 7;
            this.lbl_stats_player2WinPerc.Text = "label5";
            this.lbl_stats_player2WinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_menu
            // 
            this.btn_menu.Location = new System.Drawing.Point(627, 159);
            this.btn_menu.Margin = new System.Windows.Forms.Padding(1);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(71, 33);
            this.btn_menu.TabIndex = 46;
            this.btn_menu.Text = "Main Menu";
            this.btn_menu.UseVisualStyleBackColor = true;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(627, 212);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(1);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(71, 33);
            this.btn_exit.TabIndex = 45;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.exitProgram);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(112, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 260);
            this.panel1.TabIndex = 47;
            // 
            // lbl_stats_player1WinPerc
            // 
            this.lbl_stats_player1WinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_player1WinPerc.Location = new System.Drawing.Point(357, 364);
            this.lbl_stats_player1WinPerc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stats_player1WinPerc.Name = "lbl_stats_player1WinPerc";
            this.lbl_stats_player1WinPerc.Size = new System.Drawing.Size(134, 26);
            this.lbl_stats_player1WinPerc.TabIndex = 49;
            this.lbl_stats_player1WinPerc.Text = "label5";
            this.lbl_stats_player1WinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(353, 330);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 48;
            this.label6.Text = "Player 1 Win %";
            // 
            // ReviewButton
            // 
            this.ReviewButton.Location = new System.Drawing.Point(627, 108);
            this.ReviewButton.Margin = new System.Windows.Forms.Padding(1);
            this.ReviewButton.Name = "ReviewButton";
            this.ReviewButton.Size = new System.Drawing.Size(71, 33);
            this.ReviewButton.TabIndex = 50;
            this.ReviewButton.Text = "Review";
            this.ReviewButton.UseVisualStyleBackColor = true;
            this.ReviewButton.Click += new System.EventHandler(this.ReviewButton_Click);
            // 
            // PlayAgainButton
            // 
            this.PlayAgainButton.Location = new System.Drawing.Point(627, 55);
            this.PlayAgainButton.Margin = new System.Windows.Forms.Padding(1);
            this.PlayAgainButton.Name = "PlayAgainButton";
            this.PlayAgainButton.Size = new System.Drawing.Size(71, 33);
            this.PlayAgainButton.TabIndex = 51;
            this.PlayAgainButton.Text = "Play Again";
            this.PlayAgainButton.UseVisualStyleBackColor = true;
            this.PlayAgainButton.Click += new System.EventHandler(this.PlayAgainButton_Click);
            // 
            // WinText
            // 
            this.WinText.AutoSize = true;
            this.WinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WinText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.WinText.Location = new System.Drawing.Point(470, 27);
            this.WinText.Name = "WinText";
            this.WinText.Size = new System.Drawing.Size(73, 20);
            this.WinText.TabIndex = 52;
            this.WinText.Text = "You Win!";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 395);
            this.Controls.Add(this.WinText);
            this.Controls.Add(this.PlayAgainButton);
            this.Controls.Add(this.ReviewButton);
            this.Controls.Add(this.lbl_stats_player1WinPerc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_menu);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_stats_player2WinPerc);
            this.Controls.Add(this.lbl_stats_aiWinPerc);
            this.Controls.Add(this.lbl_stats_totalGames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_stats_gameStats);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StatsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart_stats_gameStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stats_gameStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_stats_totalGames;
        private System.Windows.Forms.Label lbl_stats_aiWinPerc;
        private System.Windows.Forms.Label lbl_stats_player2WinPerc;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_stats_player1WinPerc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ReviewButton;
        private System.Windows.Forms.Button PlayAgainButton;
        private System.Windows.Forms.Label WinText;
    }
}