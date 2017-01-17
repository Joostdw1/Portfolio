using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1_dev_op_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.ShowDialog();
        }

        private void btn_Projects_Click(object sender, EventArgs e)
        {
            projects projects = new projects();
            projects.ShowDialog();
        }

        private void btn_headquarters_Click(object sender, EventArgs e)
        {
            Headquarters headquarters = new Headquarters();
            headquarters.ShowDialog();
        }

        private void btn_budget_Click(object sender, EventArgs e)
        {
            Budget budget = new Budget();
            budget.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
