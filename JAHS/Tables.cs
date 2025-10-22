using JAHS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace JAHS
{
   public class student
    {
        public int student_id, Class_id;
        public string student_name, stud_address;

        public int stud_id
        {
            set{ student_id = value; }
            get { return student_id; }
        }            
        //public DateTime DateOfBirth;

        /*  public student(int id, string name, string address/*,DateTime dob*//*)*/
        /*  {
               student_id = id;
               student_name = name;
               stud_address = address;
               //DateOfBirth = dob;
           }*/
        /*public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - this.DateOfBirth.Year;
            if (this.DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }*/
    }
    class employee
    {
        private int emp_id;
        private string emp_name, emp_address, emp_position,priviliage;
        float emp_salary;

        public void Employee(int emp_id, string emp_name, string emp_address, string emp_position, float emp_salary,string priviliage)
        {
            this.emp_id = emp_id;
            this.emp_name = emp_name;
            this.emp_address = emp_address;
            this.emp_position = emp_position;
            this.emp_salary = emp_salary;
            this.priviliage = priviliage;
        }
        public int Emp_id
        {   get { return emp_id; }
        }
        public string Emp_name
            { get { return emp_name; } }
        public string Emp_address
            { get { return emp_address; } }
        public string Employee_position
            { get { return emp_position; } }
        public float Emp_salary
        {  get { return emp_salary; } }
        public string Priviliage
            { get { return priviliage; } }

    }
    class Teacher
    {
        private int teacher_id, teacher_class;
        private string teacher_name, teacher_address, teacher_subject;
     public Teacher(int teacher_id, int teacher_class, string teacher_name, string teacher_address, string teacher_subject)
        {
            this.teacher_id = teacher_id;
            this.teacher_class = teacher_class;
            this.teacher_name = teacher_name;
            this.teacher_address = teacher_address;
            this.teacher_subject = teacher_subject;
        }
        public string Teacher_Name
        {
            get { return this.teacher_name; }
        }
        public string Teacher_Address
        {
            get { return this.teacher_address; }
        }
        public string Teacher_Subject
        {
            get { return this.teacher_subject; }
        }
        public int Teacher_id
        {
            get { return this.teacher_id; }
        }
        public int Teacher_class
        {
            get { return this.teacher_class; }
        }
    }
        class Class
        {
            int ClassId;
            string classname;
            //int GradeLevel;
        public void Classvalue(int id,string classname)
        {
            
        }
  }
class subject
        {
        
            private string[] sub_name;
            public string[] Subjects
            {
            set {  sub_name = value; }
            get { return this.sub_name; }
            }
        }
  class mark
        {
            public int student_id, sub_id, mark_id;
            public float marks_obtained;
            mark(int student_id, int sub_id, float marks_obtained)
            {
                this.student_id = student_id;
                this.sub_id = sub_id;
                this.marks_obtained = marks_obtained;
            }
        }
    }
public static class DataManager
{
    // هذه القائمة ستكون متاحة على مستوى المشروع بأكمله
    public static List<student> AllStudents = new List<student>();
}