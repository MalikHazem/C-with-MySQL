using MySQL_Training;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MySQL_Training
{
    public partial class CreateStudent : Form
    {
        private readonly FormStudent _parent;
        public string id, name, city, gpa, is_graduate;
        public CreateStudent(FormStudent parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            labStu.Text =  "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtCity.Text = city;
            txtGPA.Text = gpa;
            txtGraduate.Text = is_graduate;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtName.Text = txtCity.Text = txtGPA.Text = txtGraduate.Text = string.Empty;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Clear()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty(" + txtName.Text.Trim().Length + " < 3). ");
                return;
            }
            if (txtCity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student city is Empty ( < 1).");
                return;
            }
            if (txtGPA.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student GPA is Empty ( < 1).");
                return;
            }
            if (txtGraduate.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student is_Graduate is Empty ( < 1).");
                return;
            }
            bool isGraduate = bool.Parse(txtGraduate.Text.Trim());
            if (btnSave.Text == "Save")
            {
                Student std = new Student(txtName.Text.Trim(), txtCity.Top, txtGPA.Top, isGraduate);
                DBStudent.AddStudent(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtCity.Top, txtGPA.Top, isGraduate);
                DBStudent.UpdateStudent(std, id);
            }
            _parent.Display();
        }

        private void CreateStudent_Load(object sender, EventArgs e)
        {

        }
    }
}