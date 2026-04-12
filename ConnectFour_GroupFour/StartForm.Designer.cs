namespace ConnectFour_GroupFour
{
    partial class StartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_sp = new System.Windows.Forms.Button();
            this.btn_tp = new System.Windows.Forms.Button();
            this.btn_stats = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_credits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect Four";
            // 
            // btn_sp
            // 
            this.btn_sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sp.Location = new System.Drawing.Point(151, 145);
            this.btn_sp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_sp.Name = "btn_sp";
            this.btn_sp.Size = new System.Drawing.Size(190, 59);
            this.btn_sp.TabIndex = 2;
            this.btn_sp.Text = "Single Player";
            this.btn_sp.UseVisualStyleBackColor = true;
            this.btn_sp.Click += new System.EventHandler(this.btn_sp_Click);
            // 
            // btn_tp
            // 
            this.btn_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tp.Location = new System.Drawing.Point(151, 226);
            this.btn_tp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_tp.Name = "btn_tp";
            this.btn_tp.Size = new System.Drawing.Size(190, 59);
            this.btn_tp.TabIndex = 3;
            this.btn_tp.Text = "Two Player";
            this.btn_tp.UseVisualStyleBackColor = true;
            this.btn_tp.Click += new System.EventHandler(this.btn_tp_Click);
            // 
            // btn_stats
            // 
            this.btn_stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stats.Location = new System.Drawing.Point(151, 311);
            this.btn_stats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_stats.Name = "btn_stats";
            this.btn_stats.Size = new System.Drawing.Size(190, 59);
            this.btn_stats.TabIndex = 4;
            this.btn_stats.Text = "Statistics";
            this.btn_stats.UseVisualStyleBackColor = true;
            this.btn_stats.Click += new System.EventHandler(this.btn_stats_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(151, 396);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(190, 59);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 489);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Created by Group 4";
            // 
            // lbl_credits
            // 
            this.lbl_credits.AutoSize = true;
            this.lbl_credits.Location = new System.Drawing.Point(442, 489);
            this.lbl_credits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_credits.Name = "lbl_credits";
            this.lbl_credits.Size = new System.Drawing.Size(59, 20);
            this.lbl_credits.TabIndex = 7;
            this.lbl_credits.Text = "Credits";
            this.lbl_credits.MouseLeave += new System.EventHandler(this.lbl_credits_MouseLeave);
            this.lbl_credits.MouseHover += new System.EventHandler(this.lbl_credits_MouseHover);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 515);
            this.Controls.Add(this.lbl_credits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_stats);
            this.Controls.Add(this.btn_tp);
            this.Controls.Add(this.btn_sp);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartForm";
            this.Text = "WelcomeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_sp;
        private System.Windows.Forms.Button btn_tp;
        private System.Windows.Forms.Button btn_stats;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_credits;
    }
}