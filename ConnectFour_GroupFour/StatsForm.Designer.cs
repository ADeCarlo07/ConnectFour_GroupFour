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
            this.chart_stats_gameStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_stats_totalGames = new System.Windows.Forms.Label();
            this.lbl_stats_aiWinPerc = new System.Windows.Forms.Label();
            this.lbl_stats_playerWinPerc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stats_gameStats)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stats_gameStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_stats_gameStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_stats_gameStats.Legends.Add(legend1);
            this.chart_stats_gameStats.Location = new System.Drawing.Point(180, 97);
            this.chart_stats_gameStats.Name = "chart_stats_gameStats";
            this.chart_stats_gameStats.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Games";
            this.chart_stats_gameStats.Series.Add(series1);
            this.chart_stats_gameStats.Size = new System.Drawing.Size(718, 373);
            this.chart_stats_gameStats.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1054, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistics";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Games";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(449, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "AI Win %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(813, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "Player Win %";
            // 
            // lbl_stats_totalGames
            // 
            this.lbl_stats_totalGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_totalGames.Location = new System.Drawing.Point(60, 559);
            this.lbl_stats_totalGames.Name = "lbl_stats_totalGames";
            this.lbl_stats_totalGames.Size = new System.Drawing.Size(187, 34);
            this.lbl_stats_totalGames.TabIndex = 5;
            this.lbl_stats_totalGames.Text = "label5";
            this.lbl_stats_totalGames.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_aiWinPerc
            // 
            this.lbl_stats_aiWinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_aiWinPerc.Location = new System.Drawing.Point(455, 559);
            this.lbl_stats_aiWinPerc.Name = "lbl_stats_aiWinPerc";
            this.lbl_stats_aiWinPerc.Size = new System.Drawing.Size(142, 39);
            this.lbl_stats_aiWinPerc.TabIndex = 6;
            this.lbl_stats_aiWinPerc.Text = "label5";
            this.lbl_stats_aiWinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_stats_playerWinPerc
            // 
            this.lbl_stats_playerWinPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stats_playerWinPerc.Location = new System.Drawing.Point(819, 559);
            this.lbl_stats_playerWinPerc.Name = "lbl_stats_playerWinPerc";
            this.lbl_stats_playerWinPerc.Size = new System.Drawing.Size(201, 39);
            this.lbl_stats_playerWinPerc.TabIndex = 7;
            this.lbl_stats_playerWinPerc.Text = "label5";
            this.lbl_stats_playerWinPerc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 649);
            this.Controls.Add(this.lbl_stats_playerWinPerc);
            this.Controls.Add(this.lbl_stats_aiWinPerc);
            this.Controls.Add(this.lbl_stats_totalGames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_stats_gameStats);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
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
        private System.Windows.Forms.Label lbl_stats_playerWinPerc;
    }
}