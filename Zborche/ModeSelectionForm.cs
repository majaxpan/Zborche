using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zborche
{
    public partial class ModeSelectionForm : Form
    {
        public string gameMode { get; set; }
        public ModeSelectionForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbEasy.Checked)
            {
                gameMode = "Easy";
            }
            else if (rbMedium.Checked)
            {
                gameMode = "Medium";
            }
            else if (rbHard.Checked)
            {
                gameMode = "Hard";
            }
            else
            {
                gameMode = "easy";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
