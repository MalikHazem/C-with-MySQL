using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQL_Training
{
    internal class DBStudent
    {
        public static MySqlConnection GetConnrction()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=c#";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("MySQL Connection!" + ex.Message, "Error", MessageBoxButtons.OK);
            }
            return conn;
        }

        public static void AddStudent(Student std)
        {
            string sql = "INSERT INTO student VALUES (NULL, @StudentName, @StudentCite, @StudentGPA, @StudentIS_Graduate)";
            MySqlConnection connr = GetConnrction();
            MySqlCommand cmd = new MySqlCommand(sql, connr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentCite", MySqlDbType.Int64).Value = std.City;
            cmd.Parameters.Add("@StudentGPA", MySqlDbType.Float).Value = std.GPA;
            cmd.Parameters.Add("@StudentIS_Graduate", MySqlDbType.Int16).Value = std.IS_Graduate;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Student not insert."+ ex.Message, "Error", MessageBoxButtons.OK);
            }
            connr.Close();
        }

        public static void UpdateStudent(Student std, string id)
        {
            string sql = "UPDATE student SET name = @StudentName, city = @StudentCite, gpa = @StudentGPA, is_graduate = @StudentIS_Graduate WHERE id = @StudentID)";
            MySqlConnection connr = GetConnrction();
            MySqlCommand cmd = new MySqlCommand(sql, connr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentCite", MySqlDbType.Int64).Value = std.City;
            cmd.Parameters.Add("@StudentGPA", MySqlDbType.Float).Value = std.GPA;
            cmd.Parameters.Add("@StudentIS_Graduate", MySqlDbType.Int16).Value = std.IS_Graduate;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully", "Information", MessageBoxButtons.OK);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not update." + ex.Message, "Error", MessageBoxButtons.OK);
            }
            connr.Close();
        }

        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM student WHERE id = @StudentID";
            MySqlConnection connr = GetConnrction();
            MySqlCommand cmd = new MySqlCommand(sql, connr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.Int64).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully", "Information", MessageBoxButtons.OK);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not delete." + ex.Message, "Error", MessageBoxButtons.OK);
            }
            connr.Close();
        }

        public static void SearchStudent(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection connr = GetConnrction();
            MySqlCommand cmd = new MySqlCommand(sql, connr);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            connr.Close();
        }
    }
}
