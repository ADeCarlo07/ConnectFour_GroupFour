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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_stats_drawPerc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stats_gameStats)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stats_gameStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_stats_gameStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_stats_gameStats.Legends.Add(legend1);
            this.chart_stats_gameStats.Location = new System.Drawing.Point(167, 97);
            this.chart_stats_gameStats.Name = "chart_stats_gameStats";
            this.chart_stats_gameStats.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Games";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Legend = "Legend1";
            series2.Name = "Highlight";
            this.chart_stats_gameStats.Series.Add(series1);
            this.chart_stats_gameStats.Series.Add(series2);
            this.chart_stats_gameStats.Size = new System.Drawing.Size(718, 374);
            this.chart_stats_gameStats.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1042, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistics";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Games";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(231, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "AI Win %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(680, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Player 2 Win %";
            // 
            // lbl_stats_totalGames
            // 
            this.lbl_stats_totalGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_totalGames.ForeColor = System.Drawing.Color.White;
            this.lbl_stats_totalGames.Location = new System.Drawing.Point(21, 559);
            this.lbl_stats_totalGames.Name = "lbl_stats_totalGames";
            this.lbl_stats_totalGames.Size = new System.Drawing.Size(157, 34);
            this.lbl_stats_totalGames.TabIndex = 5;
            this.lbl_stats_totalGames.Text = "label5";
            this.lbl_stats_totalGames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_aiWinPerc
            // 
            this.lbl_stats_aiWinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_aiWinPerc.ForeColor = System.Drawing.Color.White;
            this.lbl_stats_aiWinPerc.Location = new System.Drawing.Point(236, 553);
            this.lbl_stats_aiWinPerc.Name = "lbl_stats_aiWinPerc";
            this.lbl_stats_aiWinPerc.Size = new System.Drawing.Size(112, 40);
            this.lbl_stats_aiWinPerc.TabIndex = 6;
            this.lbl_stats_aiWinPerc.Text = "label5";
            this.lbl_stats_aiWinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_player2WinPerc
            // 
            this.lbl_stats_player2WinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_player2WinPerc.ForeColor = System.Drawing.Color.White;
            this.lbl_stats_player2WinPerc.Location = new System.Drawing.Point(685, 553);
            this.lbl_stats_player2WinPerc.Name = "lbl_stats_player2WinPerc";
            this.lbl_stats_player2WinPerc.Size = new System.Drawing.Size(184, 40);
            this.lbl_stats_player2WinPerc.TabIndex = 7;
            this.lbl_stats_player2WinPerc.Text = "label5";
            this.lbl_stats_player2WinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_menu
            // 
            this.btn_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.btn_menu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(149)))), ((int)(((byte)(217)))));
            this.btn_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu.ForeColor = System.Drawing.Color.White;
            this.btn_menu.Location = new System.Drawing.Point(927, 344);
            this.btn_menu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(106, 51);
            this.btn_menu.TabIndex = 46;
            this.btn_menu.Text = "Main Menu";
            this.btn_menu.UseVisualStyleBackColor = false;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(149)))), ((int)(((byte)(217)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(927, 435);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(106, 51);
            this.btn_exit.TabIndex = 45;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.exitProgram);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(149)))), ((int)(((byte)(217)))));
            this.panel1.Location = new System.Drawing.Point(155, 85);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 400);
            this.panel1.TabIndex = 47;
            // 
            // lbl_stats_player1WinPerc
            // 
            this.lbl_stats_player1WinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_player1WinPerc.ForeColor = System.Drawing.Color.White;
            this.lbl_stats_player1WinPerc.Location = new System.Drawing.Point(422, 553);
            this.lbl_stats_player1WinPerc.Name = "lbl_stats_player1WinPerc";
            this.lbl_stats_player1WinPerc.Size = new System.Drawing.Size(186, 40);
            this.lbl_stats_player1WinPerc.TabIndex = 49;
            this.lbl_stats_player1WinPerc.Text = "label5";
            this.lbl_stats_player1WinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(419, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 29);
            this.label6.TabIndex = 48;
            this.label6.Text = "Player 1 Win %";
            // 
            // ReviewButton
            // 
            this.ReviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.ReviewButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(149)))), ((int)(((byte)(217)))));
            this.ReviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReviewButton.ForeColor = System.Drawing.Color.White;
            this.ReviewButton.Location = new System.Drawing.Point(927, 253);
            this.ReviewButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReviewButton.Name = "ReviewButton";
            this.ReviewButton.Size = new System.Drawing.Size(106, 51);
            this.ReviewButton.TabIndex = 50;
            this.ReviewButton.Text = "Review";
            this.ReviewButton.UseVisualStyleBackColor = false;
            this.ReviewButton.Click += new System.EventHandler(this.ReviewButton_Click);
            // 
            // PlayAgainButton
            // 
            this.PlayAgainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.PlayAgainButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(149)))), ((int)(((byte)(217)))));
            this.PlayAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayAgainButton.ForeColor = System.Drawing.Color.White;
            this.PlayAgainButton.Location = new System.Drawing.Point(927, 163);
            this.PlayAgainButton.Margin = new System.Windows.Forms.Padding(2);
            this.PlayAgainButton.Name = "PlayAgainButton";
            this.PlayAgainButton.Size = new System.Drawing.Size(106, 51);
            this.PlayAgainButton.TabIndex = 51;
            this.PlayAgainButton.Text = "Play Again";
            this.PlayAgainButton.UseVisualStyleBackColor = false;
            this.PlayAgainButton.Click += new System.EventHandler(this.PlayAgainButton_Click);
            // 
            // WinText
            // 
            this.WinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WinText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.WinText.Location = new System.Drawing.Point(922, 85);
            this.WinText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WinText.Name = "WinText";
            this.WinText.Size = new System.Drawing.Size(132, 76);
            this.WinText.TabIndex = 52;
            this.WinText.Text = "You Win!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(942, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 29);
            this.label5.TabIndex = 53;
            this.label5.Text = "Draw %";
            // 
            // lbl_stats_drawPerc
            // 
            this.lbl_stats_drawPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_drawPerc.ForeColor = System.Drawing.Color.White;
            this.lbl_stats_drawPerc.Location = new System.Drawing.Point(947, 553);
            this.lbl_stats_drawPerc.Name = "lbl_stats_drawPerc";
            this.lbl_stats_drawPerc.Size = new System.Drawing.Size(98, 40);
            this.lbl_stats_drawPerc.TabIndex = 54;
            this.lbl_stats_drawPerc.Text = "label5";
            this.lbl_stats_drawPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(40)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1066, 608);
            this.Controls.Add(this.lbl_stats_drawPerc);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_stats_drawPerc;
    }
}