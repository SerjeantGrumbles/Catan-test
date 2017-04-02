using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTest1._1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            PlayerSelect playerSelect = new PlayerSelect();
            playerSelect.Show();
            this.Hide();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.catan.com/en/download/?SoC_rv_Rules_091907.pdf");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
