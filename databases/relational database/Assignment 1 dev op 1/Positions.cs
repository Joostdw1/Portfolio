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
    public partial class Positions : Form
    {
        public Positions()
        {
            InitializeComponent();
            get_data_cBpositions();
            get_all_data_position();
        }
        
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Joost;Database=assignments_dev_op1;");  //Server=127.0.0.1;Port=5432;

        public string position_name;

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
        public void get_all_data_position()
        {
            tb_position_name.Text = "";
            tb_description.Text = "";
            tb_hour_fee.Text = "";

            List<object> data_positions2 = new List<object>();
            string SQL_positions2 = "SELECT position_name, description, hour_Fee FROM positions ORDER BY position_name ASC";
            data_positions2 = get_data(SQL_positions2);

            if (data_positions2.Count() > 0)
            {
                for (int i = 0; i < data_positions2.Count(); i = i + 3)
                {
                    tb_position_name.Text = tb_position_name.Text + Convert.ToString(data_positions2[i]) + Environment.NewLine;
                    tb_description.Text = tb_description.Text + Convert.ToString(data_positions2[i + 1]) + Environment.NewLine;
                    tb_hour_fee.Text = tb_hour_fee.Text + Convert.ToString(data_positions2[i + 2]) + Environment.NewLine;
                }
            }
        }
        public void get_data_position()
        {
            if (cB_position_name2.Text != "")   //check if position_name2 textbox is empty
            {
                position_name = cB_position_name2.Text;
            }
            
            tb_description2.Text = "";
            tb_hour_fee2.Text = "";

            List<object> data_positions = new List<object>();
            string SQL_positions = "SELECT description, hour_Fee FROM positions where position_name='" + position_name + "' ";
            data_positions = get_data(SQL_positions);

            if (data_positions.Count() > 0)
            {
                tb_description2.Text = Convert.ToString(data_positions[0]);
                tb_hour_fee2.Text = Convert.ToString(data_positions[1]);
            }
        }
        public void get_data_cBpositions()
        {
            List<object> data_cBpositions = new List<object>();
            data_cBpositions = get_data("SELECT position_name FROM positions ORDER BY position_name ASC");

            if (data_cBpositions.Count() > 0)
            {
                for (int i = 0; i < data_cBpositions.Count(); i++)
                {
                    cB_position_name2.Items.Add(data_cBpositions[i]);
                }
            }
        }

        private void btn_execute_position_Click(object sender, EventArgs e)
        {
            position_name = cB_position_name2.Text;
            string description = tb_description2.Text;
            string hour_fee = tb_hour_fee2.Text;

            if (cb_add_position.Checked == true)
            {
                string SQL = "INSERT INTO positions(position_name, description, hour_fee) VALUES ('" + position_name + "', '" + description + "', " + hour_fee + ")";
                string message = "Data succesfully saved!";
                execute_data(SQL, message);
            }
            if (cb_delete_position.Checked == true)
            {
                string SQL = "DELETE FROM positions WHERE position_name='" + position_name + "' ";
                string message = "Data succesfully deleted!";
                execute_data(SQL, message);
            }
            if (cb_modify_position.Checked == true)
            {
                string SQL = "UPDATE positions SET description='" + description + "', hour_fee=" + hour_fee + " WHERE position_name='" + position_name + "' ";
                string message = "Data succesfully modified!";
                execute_data(SQL, message);
            }
            get_data_position();
            get_all_data_position();
            get_data_cBpositions();
        }   //
        
        private void btn_get_positions_Click(object sender, EventArgs e)
        {
            get_all_data_position();
        }   //get all positions from database
        
        private void cB_position_name2_TextChanged(object sender, EventArgs e)
        {
            get_data_position();
        }   //get position with position_name

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //Go to previous menu

        //checkboxes-----------------------------------------------------------------
        private void cb_add_position_CheckedChanged_1(object sender, EventArgs e)
        {
            cb_delete_position.Checked = false;
            cb_modify_position.Checked = false;
        }
        private void cb_delete_position_CheckedChanged_1(object sender, EventArgs e)
        {
            cb_add_position.Checked = false;
            cb_modify_position.Checked = false;
        }
        private void cb_modify_position_CheckedChanged_1(object sender, EventArgs e)
        {
            cb_add_position.Checked = false;
            cb_delete_position.Checked = false;
        }
        //checkboxes-----------------------------------------------------------------
    
        private void Positions_Load(object sender, EventArgs e) { } //(old)
    }
}
