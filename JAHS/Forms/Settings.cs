using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAHS
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Toolstrip_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                switch (menuItem.Name)
                {
                    case "close":
                        Application.Exit();
                        break;

                }

            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 10;
            trackBar1.Minimum = 1;
            timer1.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            this.Size = new Size(a, a);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.ToString();
        }
    }
}
