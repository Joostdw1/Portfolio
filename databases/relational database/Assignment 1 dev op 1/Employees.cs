using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Assignment_1_dev_op_1
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            get_data_cBmainheadquarter();
            get_data_cBprojectid();
            get_data_cBbsn();
        }

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Joost;Database=assignments_dev_op1;");  //Server=127.0.0.1;Port=5432;

        public int bsn;
        public string name, surname, main_headquarter;
        public string column;
        public string position_name;
        public int project_id, amount_of_hours;
        public string table;//table name

        public void execute_data(string SQL, string message)
        {
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(SQL, conn);
                int rowsaffected = cmd.ExecuteNonQuery();
                if (Convert.ToBoolean(rowsaffected))
                {
                    MessageBox.Show(message);
                }
                conn.Close();
            }
            catch (Exception exp) { MessageBox.Show("..."); }

            try { conn.Close(); }
            catch (Exception) { MessageBox.Show("Error on closing connection"); }
        }
        public List<object> get_data(string SQL)
        {
            List<object> data = new List<object>();

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(SQL, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    data.Add(dr[i]);
                }
            }
            conn.Close();
            return data;
        }
        public void get_data_employee()
        {
            if (cB_bsn.Text != "")  //check if bsn textbox is emty
            {
                bsn = Convert.ToInt32(cB_bsn.Text);
            }
            List<object> data_employees = new List<object>();
            List<object> data_positions = new List<object>();
            List<object> data_adresses = new List<object>();
            List<object> data_degrees = new List<object>();

            //string SQL_employees = "SELECT E.name, E.surname, E.main_headquarter, W.position_name, W.project_id, W.amount_of_hours FROM employees E LEFT JOIN works_as W ON E.bsn=W.bsn WHERE E.bsn=" + bsn + " ";
            string SQL_employees = "SELECT name, surname, main_headquarter FROM employees where bsn=" + bsn + " ";
            string SQL_positions = "SELECT position_name, project_id, amount_of_hours FROM works_as where bsn=" + bsn + " ";
            string SQL_adresses = "SELECT R.country, R.postal_code, A.city, A.street, A.number, R.residence FROM residence R, adresses A where R.bsn=" + bsn + " AND R.country=A.country AND R.postal_code=A.postal_code";
            string SQL_degrees = "SELECT course, school, level FROM degrees where bsn=" + bsn + " ";
            data_employees = get_data(SQL_employees);
            data_positions = get_data(SQL_positions);
            data_adresses = get_data(SQL_adresses);
            data_degrees = get_data(SQL_degrees);

            tb_name.Text = "";
            tb_surname.Text = "";
            cB_headquarter.Text = "";

            tb_position_name.Text = "";
            tb_project.Text = "";
            tb_hours.Text = "";

            tb_country.Text = "";
            tb_postal_code.Text = "";
            tb_city.Text = "";
            tb_street.Text = "";
            tb_nr.Text = "";
            tb_residence.Text = "";
            cb_residence.Checked = false;

            tb_course.Text = "";
            tb_school.Text = "";
            tb_level.Text = "";

            if (data_employees.Count() > 0)
            {
                tb_name.Text = Convert.ToString(data_employees[0]);
                tb_surname.Text = Convert.ToString(data_employees[1]);
                cB_headquarter.Text = Convert.ToString(data_employees[2]);
            }
            cb_position_name2.Items.Clear();
            if (data_positions.Count() > 0)
            {
                for (int i = 0; i < data_positions.Count(); i = i + 3)
                {
                    tb_position_name.Text = tb_position_name.Text + Convert.ToString(data_positions[i]) + Environment.NewLine;
                    tb_project.Text = tb_project.Text + Convert.ToString(data_positions[i + 1]) + Environment.NewLine;
                    tb_hours.Text = tb_hours.Text + Convert.ToString(data_positions[i + 2]) + Environment.NewLine;
                    cb_position_name2.Items.Add(data_positions[i]);
                }
            }
            if (data_adresses.Count() > 0)
            {
                for (int i = 0; i < data_adresses.Count(); i = i + 6)
                {
                    tb_country.Text = tb_country.Text + Convert.ToString(data_adresses[i]) + Environment.NewLine;
                    tb_postal_code.Text = tb_postal_code.Text + Convert.ToString(data_adresses[i + 1]) + Environment.NewLine;
                    tb_city.Text = tb_city.Text + Convert.ToString(data_adresses[i + 2]) + Environment.NewLine;
                    tb_street.Text = tb_street.Text + Convert.ToString(data_adresses[i + 3]) + Environment.NewLine;
                    tb_nr.Text = tb_nr.Text + Convert.ToString(data_adresses[i + 4]) + Environment.NewLine;
                    tb_residence.Text = tb_residence.Text + Convert.ToString(data_adresses[i + 5]) + Environment.NewLine;
                }
            }
            if (data_degrees.Count() > 0)
            {
                for (int i = 0; i < data_degrees.Count(); i = i + 3)
                {
                    tb_course.Text = tb_course.Text + Convert.ToString(data_degrees[i]) + Environment.NewLine;
                    tb_school.Text = tb_school.Text + Convert.ToString(data_degrees[i + 1]) + Environment.NewLine;
                    tb_level.Text = tb_level.Text + Convert.ToString(data_degrees[i + 2]) + Environment.NewLine;
                }
            }
        }
        public void get_data_position()
        {
            if (cB_bsn.Text != "" && cb_position_name2.Text != "")  //check if bsn and position_name2 is empty
            {
                bsn = Convert.ToInt32(cB_bsn.Text);
                position_name = cb_position_name2.Text;
            }

            cB_project2.Text = "";
            tb_hours2.Text = "";

            List<object> data_positions = new List<object>();
            string SQL_positions = "SELECT position_name, project_id, amount_of_hours FROM works_as where bsn=" + bsn + " AND position_name='" + position_name + "' ";
            data_positions = get_data(SQL_positions);

            if (data_positions.Count() > 0)
            {
                cb_position_name2.Text = Convert.ToString(data_positions[0]);
                cB_project2.Text = Convert.ToString(data_positions[1]);
                tb_hours2.Text = Convert.ToString(data_positions[2]);
            }

        }
        public void get_data_cBmainheadquarter()
        {
            List<object> data_cBmainheadquarter = new List<object>();
            data_cBmainheadquarter = get_data("SELECT building_name FROM headquarters ORDER BY building_name ASC");

            if (data_cBmainheadquarter.Count() > 0)
            {
                for (int i = 0; i < data_cBmainheadquarter.Count(); i++)
                {
                    cB_headquarter.Items.Add(data_cBmainheadquarter[i]);
                }
            }
        }
        public void get_data_cBprojectid()
        {
            List<object> data_cBprojectid = new List<object>();
            data_cBprojectid = get_data("SELECT project_id FROM projects ORDER BY project_id ASC");
            
            if (data_cBprojectid.Count() > 0)
            {
                for (int i = 0; i < data_cBprojectid.Count(); i++)
                {
                    cB_project2.Items.Add(data_cBprojectid[i]);
                }
            }
        }
        public void get_data_cBbsn()
        {
            List<object> data_cBbsn = new List<object>();
            data_cBbsn = get_data("SELECT bsn FROM employees ORDER BY bsn ASC");
            cB_bsn.Items.Clear();
            if (data_cBbsn.Count() > 0)
            {
                for (int i = 0; i < data_cBbsn.Count(); i++)
                {
                    cB_bsn.Items.Add(data_cBbsn[i]);
                }
            }
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if (cb_add_employee.Checked == true | cb_delete_employee.Checked == true | cb_modify_employee.Checked == true)
            {
                bsn = 0;
                if (cB_bsn.Text != "")
                {
                    bsn = Convert.ToInt32(cB_bsn.Text);
                }
                name = tb_name.Text;
                surname = tb_surname.Text;
                main_headquarter = cB_headquarter.Text;
                table = "employees";

                if (cb_add_employee.Checked == true)
                {
                    string SQL = "INSERT INTO " + table + "(bsn, name, surname, main_headquarter) VALUES (" + bsn + ", '" + name + "', '" + surname + "', '" + main_headquarter + "')";
                    string message = "Data succesfully saved!";
                    execute_data(SQL, message);
                }
                if (cb_delete_employee.Checked == true)
                {
                    string SQL = "DELETE FROM " + table + " WHERE bsn=" + bsn + " ";
                    string message = "Data succesfully deleted!";
                    execute_data(SQL, message);
                }
                if (cb_modify_employee.Checked == true)
                {
                    string SQL = "UPDATE " + table + " SET name='" + name + "', surname='" + surname + "', main_headquarter='" + main_headquarter + "' WHERE bsn=" + bsn + " ";
                    string message = "Data succesfully modified!";
                    execute_data(SQL, message);
                }
                get_data_employee();
                get_data_cBbsn();
            }
            else{MessageBox.Show("Please check an operation checkbox");}
        }   //
        private void btn_execute_position_Click(object sender, EventArgs e)
        {
            if (cb_add_position.Checked == true | cb_delete_position.Checked == true | cb_modify_position.Checked == true)
            {
                if (cB_bsn.Text != "")
                {
                    bsn = Convert.ToInt32(cB_bsn.Text);
                }
                position_name = cb_position_name2.Text;
                project_id = 0;
                if (cB_project2.Text != "")
                {
                    project_id = Convert.ToInt32(cB_project2.Text);
                }
                amount_of_hours = 0;
                if (tb_hours2.Text != "")
                {
                    amount_of_hours = Convert.ToInt32(tb_hours2.Text);
                }
                table = "works_as";

                if (cb_add_position.Checked == true)
                {
                    string SQL = "INSERT INTO " + table + "(bsn, position_name, project_id, amount_of_hours) VALUES(" + bsn + ", '" + position_name + "', " + project_id + ", " + amount_of_hours + ")";
                    string message = "Data succesfully saved!";
                    execute_data(SQL, message);
                }
                if (cb_delete_position.Checked == true)
                {
                    string SQL = "DELETE FROM " + table + " WHERE bsn=" + bsn + " AND position_name='" + position_name + "' ";
                    string message = "Data succesfully deleted!";
                    execute_data(SQL, message);
                }
                if (cb_modify_position.Checked == true)
                {
                    string SQL = "UPDATE " + table + " SET amount_of_hours=" + amount_of_hours + ", project_id=" + project_id + " WHERE bsn=" + bsn + " AND position_name='" + position_name + "' ";
                    string message = "Data succesfully modified!";
                    execute_data(SQL, message);
                }
                get_data_employee();
            }
            else { MessageBox.Show("Please check an operation checkbox"); }
        }   //
        private void cb_position_name2_TextChanged(object sender, EventArgs e)
        {
            get_data_position();
        }   //get position data with position_name
        private void btn_make_position_Click(object sender, EventArgs e)
        {
            Positions positions = new Positions();
            positions.ShowDialog();
        }   //Open position menu to manage positions
        private void btn_execute_adress_Click(object sender, EventArgs e)
        {
            if (cb_add_adress.Checked == true | cb_delete_adress.Checked == true | cb_modify_adress.Checked == true)
            {
                if (cB_bsn.Text != "")
                {
                    bsn = Convert.ToInt32(cB_bsn.Text);
                }
                string country = tb_country2.Text;
                string postal_code = tb_postal_code2.Text;
                string city = tb_city2.Text;
                string street = tb_street2.Text;
                int nr = 0;
                if (tb_nr2.Text != "")
                {
                    nr = Convert.ToInt32(tb_nr2.Text);
                }
                string residence = "false";
                if (cb_residence.Checked == true)
                {
                    residence = "true";
                }

                table = "residence";

                if (cb_add_adress.Checked == true)
                {
                    string SQL2 = "INSERT INTO adresses(country, postal_code, city, street, number) VALUES ('" + country + "', '" + postal_code + "', '" + city + "', '" + street + "', " + nr + ")";
                    string message2 = "New adress succesfully saved!";
                    execute_data(SQL2, message2);
                    string SQL = "INSERT INTO residence(bsn, country, postal_code, residence) VALUES (" + bsn + ", '" + country + "', '" + postal_code + "', '" + residence + "')";
                    string message = "Data succesfully saved!";
                    execute_data(SQL, message);
                }
                if (cb_delete_adress.Checked == true)
                {
                    string SQL = "DELETE FROM residence WHERE bsn=" + bsn + " AND country='" + country + "' AND postal_code='" + postal_code + "' ";
                    string message = "Data succesfully deleted!";
                    execute_data(SQL, message);
                }
                if (cb_modify_adress.Checked == true)
                {
                    string SQL = "UPDATE residence SET country='" + country + "', postal_code='" + postal_code + "', residence='" + residence + "' WHERE bsn=" + bsn + " AND country='" + country + "' AND postal_code='" + postal_code + "' ";
                    string message = "Data succesfully modified!";
                    execute_data(SQL, message);
                }
                get_data_employee();
            }
            else { MessageBox.Show("Please check an operation checkbox"); }
        }   //
        private void btn_execute_degree_Click(object sender, EventArgs e)
        {
            if (cb_add_degree.Checked == true | cb_delete_degree.Checked == true | cb_modify_degree.Checked == true)
            {
                if (cB_bsn.Text != "")
                {
                    bsn = Convert.ToInt32(cB_bsn.Text);
                }
                string course = tb_course2.Text;
                string school = tb_school2.Text;
                string level = tb_level2.Text;

                if (cb_add_degree.Checked == true)
                {
                    string SQL = "INSERT INTO degrees(bsn, course, school, level) VALUES (" + bsn + ", '" + course + "', '" + school + "', '" + level + "')";
                    string message = "Data succesfully saved!";
                    execute_data(SQL, message);
                }
                if (cb_delete_degree.Checked == true)
                {
                    string SQL = "DELETE FROM degrees WHERE bsn=" + bsn + " AND course='" + course + "' AND school='" + school + "' AND level='" + level + "' ";
                    string message = "Data succesfully deleted!";
                    execute_data(SQL, message);
                }
                if (cb_modify_degree.Checked == true)
                {
                    string SQL = "UPDATE degrees SET course='" + course + "' AND school='" + school + "' AND level='" + level + "' WHERE bsn=" + bsn + " AND course='" + course + "' AND school='" + school + "' AND level='" + level + "'  ";
                    string message = "Data succesfully modified!";
                    execute_data(SQL, message);
                }
                get_data_employee();
            }
            else { MessageBox.Show("Please check an operation checkbox"); }
        }   //
        
        private void tb_bsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid value");
            }
        }   //allows only numbers(, backspace, and delete) in bsn textbox
        private void tb_bsn_TextChanged(object sender, EventArgs e)
        {
            get_data_employee();
        }   //get employee data with bsn number
        
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //Go to previous menu

        //checkboxes-----------------------------------------------------------------
        private void cb_add_employee_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_employee.Checked = false;
            cb_modify_employee.Checked = false;
        }
        private void cb_delete_employee_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_employee.Checked = false;
            cb_modify_employee.Checked = false;
        }
        private void cb_modify_employee_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_employee.Checked = false;
            cb_delete_employee.Checked = false;
        }
        private void cb_add_position_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_position.Checked = false;
            cb_modify_position.Checked = false;
        }
        private void cb_delete_position_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_position.Checked = false;
            cb_modify_position.Checked = false;
        }
        private void cb_modify_position_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_position.Checked = false;
            cb_delete_position.Checked = false;
        }
        private void cb_add_adress_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_adress.Checked = false;
            cb_modify_adress.Checked = false;
        }
        private void cb_delete_adress_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_adress.Checked = false;
            cb_modify_adress.Checked = false;
        }
        private void cb_modify_adress_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_adress.Checked = false;
            cb_delete_adress.Checked = false;
        }
        private void cb_add_degree_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_degree.Checked = false;
            cb_modify_degree.Checked = false;
        }
        private void cb_delete_degree_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_degree.Checked = false;
            cb_modify_degree.Checked = false;
        }
        private void cb_modify_degree_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_degree.Checked = false;
            cb_delete_degree.Checked = false;
        }
        //checkboxes-----------------------------------------------------------------

        private void cb_position_name2_KeyPress(object sender, KeyPressEventArgs e){}   //(old)
    }
}