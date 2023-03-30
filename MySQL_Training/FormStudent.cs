using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_Training
{
    public partial class FormStudent : Form
    {
        CreateStudent form;
        public FormStudent()
        {
            InitializeComponent();
            form = new CreateStudent(this);
        }

        public void Display()
        {
            DBStudent.SearchStudent("SELECT * FROM student", dataGridView);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

        }

        private void FormStudent_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DBStudent.SearchStudent("SELECT * FROM student WHERE name LIKE '% " + txtSearch.Text + " %'", dataGridView);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                form.Clear();
                form.id= dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.city = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.gpa = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.is_graduate = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Are you want to delete student record?", "information", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    DBStudent.DeleteStudent(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return ;
            }
        }
    }
}
