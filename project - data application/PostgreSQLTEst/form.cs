using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Web.UI.DataVisualization.Charting;
using GMap.NET.MapProviders;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET;

namespace GraphGenerator
{
    public partial class Form1 : Form
    {
        public string locreadpart;
        public string datum = "";
        public string tijd = "";
        public double average = 0;
        public int averagecounter = 0;
        public int dateread = 0;
        public int maxdate = 0;
        public string timezero = "0";
        public string datezero = "0";
        public string yread = "";
        public string locread = "";
        public string chartselect = "";
        public int timeread = 0;


        public void button2_Click(object sender, EventArgs e)
        {
            rungraphs();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "line width = " + trackBar3.Value.ToString();
            foreach (object serie in (chart1.Series)) { chart1.Series[(serie.ToString()).Remove(0, 7)].BorderWidth = trackBar3.Value; };
        }
        private void trackBar1_Scroll(object sender, EventArgs e) { label1.Text = "minimum date = " + trackBar1.Value.ToString(); }
        private void trackBar2_Scroll(object sender, EventArgs e) { label2.Text = "maximum date = " + trackBar2.Value.ToString(); }
        private void checkedListBoxX_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkedListBoxX.CheckedItems.Count > 1)
            {
                MessageBox.Show("You cannot select more than one element.", "Error");
                checkedListBoxX.ClearSelected();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            traffic();
        }
    }
}
