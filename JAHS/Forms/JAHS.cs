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
    public partial class JAHS : Form
    {
        public JAHS()
        {
            InitializeComponent();
            //toolsToolStripMenuItem.Name.EndsWith("l");
        }
        private void Toolstrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                switch (menuItem.Name)
                {
                    case "LogoutToolStripMenuItem":
                        this.Close();
                        Login login = new Login();
                        login.Show();
                        break;
                    case "exitToolStripMenuItem":
                        Application.Exit();
                        break;
                    case "StudentAffairsToolStripMenuItem":
                        this.Close();
                        StudentAffairs studform = new StudentAffairs();
                        studform.Show();
                        break;
                    case "StaffManagementToolStripMenuItem":
                        this.Close();
                        StaffManagement staffManagement = new StaffManagement();
                        staffManagement.Show();
                        break;
                    case "academicAffairsToolStripMenuItem":
                        this.Close();
                        AcademicAffairs academicAffairs = new AcademicAffairs();
                        academicAffairs.Show();
                        break;
                    case "reportsToolStripMenuItem":
                        this.Close();
                        Reports reports = new Reports();
                        reports.Show();
                        break;
                    case "settingsToolStripMenuItem":
                        this.Close();
                        Settings settings = new Settings(); 
                        settings.Show();
                        break;
                }

            }
            
        }
    }
}
