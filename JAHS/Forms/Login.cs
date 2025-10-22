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
    public partial class Login : Form
    {
        int attemps = 3;
        string username = "JAHS", Password = "M123";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("D:\\Projects\\C#\\عملي\\Final Project\\Images\\School.jpeg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            label1.Text = "Username";
            label2.Text = "Password";
            label1.BackColor = SystemColors.Highlight;
            label2.BackColor = SystemColors.Highlight;
            User.BackColor = Color.LawnGreen;
            Pass.BackColor = Color.LawnGreen;
            User.ForeColor = SystemColors.Highlight;
            Pass.ForeColor = SystemColors.Highlight;
            pictureBox1.Image = Image.FromFile("D:\\Projects\\C#\\عملي\\Final Project\\Images\\JAHS-logo.jpg");
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            groupBox1.BackgroundImage = Image.FromFile("D:\\Projects\\C#\\عملي\\Final Project\\Images\\JAHS-ST.7.png");
            groupBox1.BackgroundImageLayout = ImageLayout.Stretch;
            Enter.Text = "Log in";
            User.Focus();
            progressBar1.Hide();
            progressBar1.Maximum = 50;
            progressBar1.Value = 0;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(User.Text) || string.IsNullOrEmpty(Pass.Text)) && attemps != 0)
            {
                MessageBox.Show("Empty Field,Enter Username and password");
                attemps--;
                MessageBox.Show(attemps + " attemps left");
                if (attemps == 0)
                {
                    MessageBox.Show("No Attemps Left");
                    Enter.Enabled = false;
                }
            }
            else if (User.Text == username && Pass.Text == Password)
            {
                progressBar1.Show();
                timer1.Enabled = true;
                timer1.Start();
            }
            else /*if (User.Text!=username || Pass.Text!=Password)*/
            {
                MessageBox.Show("Check Username or password");
                attemps--;
                MessageBox  .Show(attemps + " attemps left");
                if (attemps == 0)
                {
                    MessageBox.Show("No Attemps Left");
                    this.Close();
                }
            }
        }

        private void show_pass_CheckedChanged(object sender, EventArgs e)
        {
            if(show_pass.Checked)
                Pass.UseSystemPasswordChar = false;
                else 
                Pass.UseSystemPasswordChar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                
                progressBar1.Value += 10;
                
            Application.DoEvents();
            }
            else 

            {
              
                timer1.Stop();
                JAHS jAHS = new JAHS();
                jAHS.Show();
                this.Hide();
                MessageBox.Show("Welcome");
            }

        }
           
        }
        
}

