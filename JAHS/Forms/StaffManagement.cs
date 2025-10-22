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
    public partial class StaffManagement : Form
    {

        subject Subj=new subject();
        public StaffManagement()
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
                    case "Close":
                        Application.Exit();
                        break;
                }
            }
        }

        private void teacher_Data_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(teacher_id.Text) || string.IsNullOrEmpty(teacher_name.Text) || string.IsNullOrEmpty(teacher_address.Text) || string.IsNullOrEmpty(teacher_class.Text))

                MessageBox.Show("Fill Empty Field", "Warnnig", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                Teacher teacher = new Teacher(int.Parse(teacher_id.Text), int.Parse(teacher_class.Text), teacher_name.Text,
                  teacher_address.Text, teacher_subject.Text);

                object[] teacher_Data = new object[]
        {
                teacher.Teacher_id, teacher.Teacher_Name, teacher.Teacher_Address, teacher.Teacher_class
        };
                dataGridView1.Rows.Add(teacher_Data);
                MessageBox.Show("teacherent Added");
                tabPage1.Hide();
                tabPage2.Show();

            }
        }

        private void StaffManagement_Load(object sender, EventArgs e)
        {
            string[] subject = new string[]
            {
                "Arabbic Language","Biology","Chemistry","Community","English Language",
                "Geographiec","History","Islamic Education","Mathematics","Physics","Holy Quran"
            };
            Subj.Subjects = subject;
            teacher_subject.Items.AddRange(subject);
        }

        private void teacher_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Number Only");
            }
        }

        private void teacher_subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Choose From the box");
        }

      

        private void teacher_cont(object sender, EventArgs e)
        {
            Button teacher = (Button)sender;
            switch (teacher.Text)
            {
                case "Add":
                    {
                        this.Hide();
                        tabPage1.Show();
                    }
                    break;
                default:
                    dataGridView1.SelectedRows.Clear(); break;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            switch (a)
            {
                case 1:
                    priviliage.Text = "User";break;
                case 2:
                    priviliage.Text = "Employee";break;
                case 3:
                    priviliage.Text = "Supervision";break;
                case 4:
                    priviliage.Text = "Adminstrator";break;
                    case 5:
                    priviliage.Text = "System Maneger";break;
            }
        }

        private void emp_data_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(emp_id.Text) || string.IsNullOrEmpty(emp_name.Text) || string.IsNullOrEmpty(emp_address.Text) || string.IsNullOrEmpty(emp_sal.Text))
                MessageBox.Show("Fill Empty Field", "Warnnig", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                employee emp = new employee();
                emp.Employee(int.Parse(emp_id.Text), emp_name.Text, emp_address.Text, emp_pos.Text, float.Parse(emp_sal.Text),emp_privi.Text);
                object[] Employee = new object[]
                {
                    emp.Emp_id,emp.Emp_name,emp.Emp_address,emp.Employee_position,emp.Emp_salary,emp.Priviliage
                };
                MessageBox.Show("Employee Added");
              //  dataGridView2.Rows.(Employee);
                tabPage1.Hide();
                tabPage2.Show();
            }
        }
    }
}
