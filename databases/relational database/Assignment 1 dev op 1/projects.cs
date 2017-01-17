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
    public partial class projects : Form
    {
        public projects()
        {
            InitializeComponent();
            get_data_cBprojects();
            get_all_data_project();
            get_data_cBmainheadquarter();
        }

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Joost;Database=assignments_dev_op1;");  //Server=127.0.0.1;Port=5432;

        public int project_id;

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
            catch (Exception exp) { MessageBox.Show("Error"); }

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
        public void get_all_data_project()
        {
            tb_project_id.Text = "";
            tb_budget.Text = "";
            tb_allocated_hours.Text = "";
            tb_headquarter.Text = "";

            List<object> data_projects2 = new List<object>();
            string SQL_projects2 = "SELECT project_id, budget, allocated_hours, headquarter FROM projects ORDER BY project_id ASC";
            data_projects2 = get_data(SQL_projects2);

            if (data_projects2.Count() > 0)
            {
                for (int i = 0; i < data_projects2.Count(); i = i + 4)
                {
                    tb_project_id.Text = tb_project_id.Text + Convert.ToString(data_projects2[i]) + Environment.NewLine;
                    tb_budget.Text = tb_budget.Text + Convert.ToString(data_projects2[i + 1]) + Environment.NewLine;
                    tb_allocated_hours.Text = tb_allocated_hours.Text + Convert.ToString(data_projects2[i + 2]) + Environment.NewLine;
                    tb_headquarter.Text = tb_headquarter.Text + Convert.ToString(data_projects2[i + 3]) + Environment.NewLine;
                }
            }
        }
        public void get_data_project()
        {
            if (cB_projects_id2.Text != "")   //check if project_id textbox is empty
            {
                project_id = Convert.ToInt32(cB_projects_id2.Text);
            }
            
            tb_budget2.Text = "";
            tb_allocated_hours2.Text = "";
            cB_headquarter2.Text = "";

            List<object> data_projects = new List<object>();
            string SQL_projects = "SELECT budget, allocated_hours, headquarter FROM projects where project_id=" + project_id + " ";
            data_projects = get_data(SQL_projects);

            if (data_projects.Count() > 0)
            {
                tb_budget2.Text = Convert.ToString(data_projects[0]);
                tb_allocated_hours2.Text = Convert.ToString(data_projects[1]);
                cB_headquarter2.Text = Convert.ToString(data_projects[2]);
            }
        }
        public void get_data_cBprojects()
        {
            List<object> data_cBprojects = new List<object>();
            data_cBprojects = get_data("SELECT project_id FROM projects ORDER BY project_id ASC");

            if (data_cBprojects.Count() > 0)
            {
                for (int i = 0; i < data_cBprojects.Count(); i++)
                {
                    cB_projects_id2.Items.Add(data_cBprojects[i]);
                }
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
                    cB_headquarter2.Items.Add(data_cBmainheadquarter[i]);
                }
            }
        }

        private void btn_execute_project_Click(object sender, EventArgs e)
        {
            if (cB_projects_id2.Text != "")
            {
                project_id = Convert.ToInt32(cB_projects_id2.Text);
            }
            string budget = tb_budget2.Text;
            string allocated_hours = tb_allocated_hours2.Text;
            string headquarter = cB_headquarter2.Text;

            if (cb_add_project.Checked == true)
            {
                string SQL = "INSERT INTO projects(project_id, budget, allocated_hours, headquarter) VALUES (" + project_id + ", " + budget + ", " + allocated_hours + ", '" + headquarter + "')";
                string message = "Data succesfully saved!";
                execute_data(SQL, message);
            }
            if (cb_delete_project.Checked == true)
            {
                string SQL = "DELETE FROM projects WHERE project_id=" + project_id + " ";
                string message = "Data succesfully deleted!";
                execute_data(SQL, message);
            }
            if (cb_modify_project.Checked == true)
            {
                string SQL = "UPDATE projects SET budget=" + budget + ", allocated_hours=" + allocated_hours + ", headquarter='" + headquarter + "' WHERE project_id=" + project_id + " ";
                string message = "Data succesfully modified!";
                execute_data(SQL, message);
            }
            get_data_project();
            get_all_data_project();
        }   //

        private void btn_get_projects_Click(object sender, EventArgs e)
        {
            get_all_data_project();
        }   //get all projects from database

        private void cB_projects_id2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid value");
            }
        }   //allows only numbers(, backspace, and delete) in project_id2 textbox
        private void cB_projects_id2_TextChanged(object sender, EventArgs e)
        {
            get_data_project();
        }   //get projects with project_id
        
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //Go to previous menu

        //checkboxes-----------------------------------------------------------------
        private void cb_add_project_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_project.Checked = false;
            cb_modify_project.Checked = false;
        }
        private void cb_delete_project_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_project.Checked = false;
            cb_modify_project.Checked = false;
        }
        private void cb_modify_project_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_project.Checked = false;
            cb_delete_project.Checked = false;
        }
        //checkboxes-----------------------------------------------------------------

        private void tb_project_id_TextChanged(object sender, EventArgs e){}   //(Old) 
    }
}
