using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JAHS
{
    public partial class StudentAffairs : Form
    {
        Class clas=new Class(); 
        student stud = new student();
       


        public StudentAffairs()
        {
            InitializeComponent();
        }

        private void Stud_Data_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stud_id.Text) || string.IsNullOrEmpty(stud_name.Text) || string.IsNullOrEmpty(stud_address.Text) || string.IsNullOrEmpty(stud_class.Text))

                MessageBox.Show("Fill Empty Field", "Warnnig", MessageBoxButtons.OK, MessageBoxIcon.Error);


            else
            {
                stud.student_id = int.Parse(stud_id.Text);
                stud.student_name = stud_name.Text;
                stud.Class_id = int.Parse(stud_class.Text);
                stud.stud_address = stud_address.Text;
                object[] Stud_Data = new object[]
        {
                stud.student_id, stud.student_name, stud.stud_address, stud.Class_id/*,stud_image*/
        };
                DataManager.AllStudents.Add(stud);
                dataGridView1.Rows.Add(Stud_Data);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.AllStudents; 
                MessageBox.Show("Student Added");

                stud_id.Clear();
                stud_name.Clear();
                stud_address.Clear();
                stud_class.SelectedIndex = -1;

                tabPage1.Hide();
                tabPage2.Show();

            }
        }



        private void stud_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("not allowed,Number only");
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;) |*.jpg;*.jpeg;*.png;*.gif;";
            openFileDialog1.Title = "Select a Student Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                stud_image.Image = Image.FromFile(filePath);
                stud_image.SizeMode = PictureBoxSizeMode.StretchImage;

                //rotate 90 degree to right;
            }
        }

        private void StudentAffairs_Load(object sender, EventArgs e)
        {
            //stud_class.Items.AddRange(1, 2, 3);
            stud_class.Items.Add(1);
            stud_class.Items.Add(2);
            stud_class.Items.Add(3);

            tabPage1.BackgroundImage = Image.FromFile("D:\\Projects\\C#\\عملي\\Final Project\\Images\\JAHS-ST.7.jpg");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label1.Font = new Font("Arial", 10, FontStyle.Bold);
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label3.Font = new Font("Arial", 10, FontStyle.Bold);
            label4.Font = new Font("Arial", 10, FontStyle.Bold);
            stud_image.Image = Image.FromFile(@"D:\Projects\C#\عملي\Final Project\Images\Students.JPG");
            stud_image.SizeMode = PictureBoxSizeMode.StretchImage;
            label5.ForeColor = Color.DeepSkyBlue;
            dataGridView2.Hide();
            richTextBox1.Hide();
            Note.Hide();
        }

        private void stud_class_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("chose from the list");
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            string SearchValu = Stud_Serach.Text.Trim();
            if (string.IsNullOrEmpty(SearchValu))
            {
                MessageBox.Show("Please Enter Name For Search", "Warnnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataGridView2.Rows.Clear();
            bool studentfound = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["StuName"].Value != null && row.Cells["StuName"].Value.ToString().Contains(SearchValu.ToLower()))
                {
                    dataGridView2.Show();
                    Note.Show();
                    richTextBox1.Show();
                    int rowindex = dataGridView2.Rows.Add();
                    DataGridViewRow newRow = dataGridView2.Rows[rowindex];
                    for (int i = 1; i <= row.Cells.Count; i++)
                        newRow.Cells[i].Value = row.Cells[i].Value;
                    studentfound = true;
                }
                if (!studentfound)
                    MessageBox.Show("Can't Find Student", "Resault", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /*     row.Selected = true;                                    // إذا تم العثور على الطالب تحديد الصف الذي تم العثور عليه
              dataGridView1.FirstDisplayedScrollingRowIndex = row.Index; * / تمرير العرض ليظهر الصف المحدد

                break;*/
            }
        }

        private void Note_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "text file |*.txt";
            saveFileDialog1.Title = "Save Student Note";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
        }

        private void stud_info(object sender, EventArgs e)
        {
            Button stud = (Button)sender;

            switch (stud.Text)
            {
                case "Add":
                    {
                        tabPage2.Hide();
                        tabPage1.Show();
                        break;
                    }
                default: dataGridView1.SelectedRows.Clear(); break;


            }
        }
    }
}
