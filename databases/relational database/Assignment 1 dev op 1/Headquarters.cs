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
    public partial class Headquarters : Form
    {
        public Headquarters()
        {
            InitializeComponent();
            get_data_cBheadquarters();
            get_all_data_headquarters();
        }

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Joost;Database=assignments_dev_op1;");  //Server=127.0.0.1;Port=5432;

        public string building_name;

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
        public void get_all_data_headquarters()
        {
            tb_building_name.Text = "";
            tb_rooms.Text = "";
            tb_monthly_rent.Text = "";

            List<object> data_headquarters2 = new List<object>();
            string SQL_headquarters2 = "SELECT building_name, nr_of_rooms, monthly_rent FROM headquarters ORDER BY building_name ASC";
            data_headquarters2 = get_data(SQL_headquarters2);

            if (data_headquarters2.Count() > 0)
            {
                for (int i = 0; i < data_headquarters2.Count(); i = i + 3)
                {
                    tb_building_name.Text = tb_building_name.Text + Convert.ToString(data_headquarters2[i]) + Environment.NewLine;
                    tb_rooms.Text = tb_rooms.Text + Convert.ToString(data_headquarters2[i + 1]) + Environment.NewLine;
                    tb_monthly_rent.Text = tb_monthly_rent.Text + Convert.ToString(data_headquarters2[i + 2]) + Environment.NewLine;
                }
            }
        }
        public void get_data_headquarter()
        {
            if (cB_building_name2.Text != "")   //check if building_name textbox is empty
            {
                building_name = cB_building_name2.Text;
            }

            tb_rooms2.Text = "";
            tb_monthly_rent2.Text = "";

            List<object> data_headquarters = new List<object>();
            string SQL_headquarters = "SELECT nr_of_rooms, monthly_rent FROM headquarters where building_name='" + building_name + "' ";
            data_headquarters = get_data(SQL_headquarters);

            if (data_headquarters.Count() > 0)
            {
                tb_rooms2.Text = Convert.ToString(data_headquarters[0]);
                tb_monthly_rent2.Text = Convert.ToString(data_headquarters[1]);
            }
        }
        public void get_data_cBheadquarters()
        {
            List<object> data_cBheadquarters = new List<object>();
            data_cBheadquarters = get_data("SELECT building_name FROM headquarters ORDER BY building_name ASC");

            if (data_cBheadquarters.Count() > 0)
            {
                for (int i = 0; i < data_cBheadquarters.Count(); i++)
                {
                    cB_building_name2.Items.Add(data_cBheadquarters[i]);
                }
            }
        }


        private void btn_execute_headquarter_Click(object sender, EventArgs e)
        {
            building_name = cB_building_name2.Text;
            string rooms = tb_rooms2.Text;
            string monthly_rent = tb_monthly_rent2.Text;

            if (cb_add_headquarter.Checked == true)
            {
                string SQL = "INSERT INTO headquarters(building_name, nr_of_rooms, monthly_rent) VALUES ('" + building_name + "', " + rooms + ", " + monthly_rent + ")";
                string message = "Data succesfully saved!";
                execute_data(SQL, message);
            }
            if (cb_delete_headquarter.Checked == true)
            {
                string SQL = "DELETE FROM headquarters WHERE building_name='" + building_name + "' ";
                string message = "Data succesfully deleted!";
                execute_data(SQL, message);
            }
            if (cb_modify_headquarter.Checked == true)
            {
                string SQL = "UPDATE headquarters SET nr_of_rooms=" + rooms + ", monthly_rent=" + monthly_rent + " WHERE building_name='" + building_name + "' ";
                string message = "Data succesfully modified!";
                execute_data(SQL, message);
            }
            get_data_headquarter();
            get_all_data_headquarters();
        }   //
        
        private void btn_get_headquarters_Click(object sender, EventArgs e)
        {
            get_all_data_headquarters();
        }   //get all headquarters from database

        private void cB_building_name2_TextChanged(object sender, EventArgs e)
        {
            get_data_headquarter();
        }   //get headquarters with building_name

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //Go to previous menu

        //checkboxes-----------------------------------------------------------------
        private void cb_add_headquarter_CheckedChanged(object sender, EventArgs e)
        {
            cb_delete_headquarter.Checked = false;
            cb_modify_headquarter.Checked = false;
        }
        private void cb_delete_headquarter_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_headquarter.Checked = false;
            cb_modify_headquarter.Checked = false;
        }
        private void cb_modify_headquarter_CheckedChanged(object sender, EventArgs e)
        {
            cb_add_headquarter.Checked = false;
            cb_delete_headquarter.Checked = false;
        }
        //checkboxes-----------------------------------------------------------------
    }
}
