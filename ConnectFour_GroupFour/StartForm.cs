using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConnectFour_GroupFour
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            
            //Form is loaded to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Below if we want to manual position the form to the top left as the directions mentioned
            //this.StartPosition = FormStartPosition.Manual;
            //this.Top = 0;
            //this.RightToLeft = 0;
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
            closeForms();
        }
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForms();
        }

        //function call to close the entire application
        //made public so other forms can reference
        public void closeForms()
        {
            Application.Exit();
        }
        //single player button click
        private void btn_sp_Click(object sender, EventArgs e)
        {
            loadBoard(1);
        }
        //two player button click
        private void btn_tp_Click(object sender, EventArgs e)
        {
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
            lbl_credits.ForeColor = Color.Black;
            lbl_credits.Font = new Font(lbl_credits.Font, FontStyle.Regular);
        }

        private void btn_stats_Click(object sender, EventArgs e)
        {
            StatsForm sf = new StatsForm(this);

            sf.Show();
            this.Hide();
        }
    }
}
