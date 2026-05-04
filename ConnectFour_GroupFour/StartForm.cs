//==========================================================
//Name: Allison DeCarlo, Giovanni Cuadra, Layla Kleinow,
//      Julian Miles, Elijah Wright
//Date: 05/10/2026
//Desc: Connect Four Group Project
//==========================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ConnectFour_GroupFour
{
    public partial class StartForm : Form
    {
        SoundPlayer sound_hover = new SoundPlayer(Properties.Resources.c4hoverover2);
        SoundPlayer sound_select = new SoundPlayer(Properties.Resources.c4select2);
        public StartForm()
        {
            InitializeComponent();

            btn_sp.MouseEnter += (s, e) => //when the mouse begins hovering over the button
            {
                sound_hover.Play();
                //SoundPlayer sp = new SoundPlayer(Properties.Resources.c4hoverover2);
                //btn_sp.BackColor = Color.LightBlue;
            };
            btn_tp.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };
            btn_stats.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };
            btn_exit.MouseEnter += (s, e) =>
            {
                sound_hover.Play();
            };
        }
        
        public void loadBoard(int p)
        {
            //using overloaded constructor to load the original StartForm
            //will need to update to pass if singleplayer or twoplayer is clicked down the line
            GameForm formToLoad = new GameForm(this, p);

            //loads the display form
            formToLoad.Show();

            //hides the start form
            this.Hide();
        }

        //maybe we can consolidate clicking exit and clicking close?
        private void btn_exit_Click(object sender, EventArgs e)
        {
            sound_select.Play();
            closeAll();
        }
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeAll();
        }

        //function call to close the entire application
        //made public so other forms can reference
        public void closeAll()
        {
            Application.Exit();
        }
        //single player button click
        private void btn_sp_Click(object sender, EventArgs e)
        {
            sound_select.Play();
            loadBoard(1);
        }
        //two player button click
        private void btn_tp_Click(object sender, EventArgs e)
        {
            sound_select.Play();
            loadBoard(2);
        }

        //I want to add a credits form or something later to list our names
        //for now it just turns blue when you hover over it
        private void lbl_credits_MouseHover(object sender, EventArgs e)
        {
            lbl_credits.ForeColor = Color.Blue;
            lbl_credits.Font = new Font(lbl_credits.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void lbl_credits_MouseLeave(object sender, EventArgs e)
        {
            lbl_credits.ForeColor = Color.White;
            lbl_credits.Font = new Font(lbl_credits.Font, FontStyle.Regular);
            list_credits.Visible = false;
            list_credits.Items.Clear();
        }
        private void lbl_credits_Click(object sender, EventArgs e)
        {
            if (!list_credits.Visible)
            {
                list_credits.Visible = true;
                list_credits.Items.Add("Cuadra, Giovanni");
                list_credits.Items.Add("Decarlo, Allison");
                list_credits.Items.Add("Kleinow, Layla");
                list_credits.Items.Add("Miles, Julian");
                list_credits.Items.Add("Wright, Elijah");
            }
        }
        private void btn_stats_Click(object sender, EventArgs e)
        {
            sound_select.Play();
            StatsForm sf = new StatsForm(this);

            sf.Show();
            this.Hide();
        }


    }
}
