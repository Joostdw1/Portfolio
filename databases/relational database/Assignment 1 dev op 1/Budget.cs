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
    public partial class Budget : Form
    {
        public Budget()
        {
            InitializeComponent();
            tb_budget.Text = "...";
        }

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Joost;Database=assignments_dev_op1;");  //Server=127.0.0.1;Port=5432;

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
            tb_budget.Text = "";

            List<object> data_budget = new List<object>();
            string SQL_budget = "SELECT P.project_id FROM projects P, headquarters H WHERE P.headquarter = H.building_name AND H.monthly_rent * 0.1 > P.budget ORDER BY P.project_id ASC";
            data_budget = get_data(SQL_budget);

            if (data_budget.Count() > 0)
            {
                for (int i = 0; i < data_budget.Count(); i++)
                {
                    tb_budget.Text = tb_budget.Text + "Project id: " + Convert.ToString(data_budget[i]) + Environment.NewLine;
                }
            }
            else
            {
                tb_budget.Text = "Nothing";
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            get_all_data_position();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //Go to previous menu
    }
}
