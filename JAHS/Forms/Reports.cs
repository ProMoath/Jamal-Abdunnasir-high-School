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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            string[] Report = new string[3]
            {
                "student degree","student of class","teachers"
            };
            report.Items.AddRange(Report);
            panel1.Hide();
            stud_rep.Hide();
            
        }

        private void view_Click(object sender, EventArgs e)
        {
            switch (report.SelectedIndex)
            {
                case 1:
                    {
                        panel1.Show();
                        richTextBox1.Text = "*****************************************\r\n* كشف درجات الطالب الرسمي        *\r\n*****************************************\r\n\r\nاسم الطالب: عبدالله محمد الأحمد\r\nالرقم الأكاديمي: 101\r\nالفصل: الثاني المتوسط - ج\r\nالعام الدراسي: 1445-1446هـ\r\n\r\n-----------------------------------------\r\n| المادة         | الدرجة   | التقدير   |\r\n|----------------|----------|-----------|\r\n| الرياضيات      | 95       | ممتاز     |\r\n| الفيزياء       | 92       | ممتاز     |\r\n| الكيمياء       | 88       | جيد جداً  |\r\n| اللغة العربية   | 94       | ممتاز     |\r\n| اللغة الإنجليزية| 85       | جيد جداً  |\r\n-----------------------------------------\r\n\r\nالمعدل العام: 90.8 (ممتاز)\r\n\r\nملاحظات: الطالب متفوق سلوكياً ودراسياً.\r\n-----------------------------------------\r\nتوقيع المدير: .........................\r\nالختم الرسمي";
                    }
                    break;
                    case 2: 
                    {
                        panel1.Show();
                        richTextBox1.Text = "";
                    }
                    break;
                    case 3: 
                    {
                        panel1.Show();
                    }
                    break;
            }
        }

        private void report_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Please Choose class from the list", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "text file |*.txt";
            saveFileDialog1.Title = "Save Student Degree";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
             File.WriteAllText(saveFileDialog1.FileName,richTextBox1.Text);
        }
    }
}
