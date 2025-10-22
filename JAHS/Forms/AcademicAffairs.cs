using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAHS
{
    public partial class AcademicAffairs : Form
    {
        Class clas = new Class();
        subject Subj = new subject();
        public AcademicAffairs()
        {
            InitializeComponent();
        }

        private void AcademicAffairs_Load(object sender, EventArgs e)
        {
            string[] subject = new string[]
          {
          
                "Arabbic Language","Biology","Chemistry","Community","English Language",
                "Geographiec","History","Islamic Education","Mathematics","Physics","Holy Quran"
          };
            Subj.Subjects = subject;
            subjects.Items.AddRange(subject);
            Subject.Items.AddRange(subject);

            int[] cls = new int[3]
            {
            1,2,3
            };

            classes.Items.Add(1);
            classes.Items.Add(2);
            classes.Items.Add(3);

            Classroom.Items.Add(1);
            Classroom.Items.Add(2);
            Classroom.Items.Add(3);

            // Classroom.Items.AddRange(cls);
            //classes.Items.AddRange(cls);
            Sub_add.Hide();
            Class_add.Hide();
            sub_lbl.Hide();
            cls_lbl.Hide();
            teacher_sub.Hide();
            dataGridView1_stud.Hide();
            tabPage1.BackgroundImage = Image.FromFile("D:\\Projects\\C#\\عملي\\Final Project\\Images\\School.jpeg");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void Add(object sender, EventArgs e)
        {
            //Teacher teacher = new Teacher();
            Button add = sender as Button;
            teacher_sub.Show();
            string[] teachers = new string[] {
            "Mohammed","Ali","Adel","Abdo","Khaled","Alshaikh","Alshahari"
                        };
            teacher_sub.Items.AddRange(teachers);

            switch (add.Text)
            {
                case "Add Subject":
                    {
                        sub_lbl.Show();
                        Sub_add.Show();
                        if (Sub_add.Text != null)
                        {
                            subjects.Items.Add(Sub_add.Text);
                            MessageBox.Show("Subject Added");
                        }
                        else MessageBox.Show("Please write subject");
                        break;
                    }
                case "Add Class":
                    {
                        cls_lbl.Show();
                        Class_add.Show();
                        if (Class_add.Text != null)
                        {
                            classes.Items.Add(Class_add.Text);
                            MessageBox.Show("Classes Added");
                        }
                        else MessageBox.Show("Please write Class");
                        break;
                    }
            }
            MessageBox.Show("Please Choose a Teacher To teache new subject & class");
        }

        private void teacher_sub_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Please Choose teacher from the list", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox deg = sender as ComboBox;
            e.Handled = true;
            switch (deg.Name)
            {
                case "Classroom":
                    MessageBox.Show("Please Choose class from the list", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "Subjct":
                    MessageBox.Show("Please Choose subject from the list", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }

        private void SaveDegree_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Word file |*.docx";
            saveFileDialog1.Title = "Save Student Degree";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
               // File.WriteAllText(saveFileDialog1.FileName, dataGridView1_stud.SelectedRows);
        }

        private void Classroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Classroom.SelectedItem == null)
                return;
            dataGridView1_stud.Show();
            if (int.TryParse(Classroom.SelectedItem.ToString(), out int selectedClassId))
            {
                // استخدام LINQ لفلترة قائمة الطلاب بناءً على الفصل المختار
                // Where: تقوم بالبحث عن كل طالب (s) يحقق الشرط s.Class_id == selectedClassId
                // ToList: تحول النتائج إلى قائمة جديدة
               // var filteredStudents = DataManager.AllStudents.Where(s => s.Class_id == selectedClassId).ToList();

                // ربط جدول البيانات بالطلاب الذين تم فلترتهم
              //  dataGridView1_stud.DataSource = filteredStudents;

                // (اختياري) يمكنك تخصيص الأعمدة التي تريد عرضها فقط
                // تأكد من أن أسماء الخصائص (student_id, student_name) مطابقة لما في كلاس student
                dataGridView1_stud.Columns["student_id"].HeaderText = "ID";
                dataGridView1_stud.Columns["student_name"].HeaderText = "Name";

                // إخفاء الأعمدة الأخرى إذا أردت
                if (dataGridView1_stud.Columns.Contains("stud_address"))
                {
                    dataGridView1_stud.Columns["stud_address"].Visible = false;
                }
                if (dataGridView1_stud.Columns.Contains("Class_id"))
                {
                    dataGridView1_stud.Columns["Class_id"].Visible = false;
                }
            }
        }
    }
}
