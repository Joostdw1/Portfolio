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
    public partial class Form1
    {

        public Form1()
        {
            InitializeComponent();
            progressBar1.Hide();
            chart1.Hide();
            label3.Text = "line width = " + trackBar3.Value.ToString();
            //Initialize Google Maps
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            GMapProvider.WebProxy = null;
            gMapControl1.SetPositionByKeywords("Rotterdam, The Netherlands");
            gMapControl1.Hide();
        }

        public void rungraphs() {

            chart1.Hide();
            yread = ""; locread = ""; chartselect = "";
            //checks checked items
            foreach (string s in checkedListBoxX.CheckedItems) { yread = yread + s; }
            foreach (string s in checkedListBox1.CheckedItems) { locread = locread + s; }
            foreach (string s in checkedListBox2.CheckedItems) { chartselect = s; }

            timezero = "0";
            datezero = "0";
            if (yread == "") { MessageBox.Show("Please insert at least one element.", "Error"); }
            if (locread == "") { MessageBox.Show("Please insert at least one location.", "Error"); }
            if (chartselect == "") { MessageBox.Show("Please select your chart style.", "Error"); }
            else
            {
                string connstring = String.Format("Server=127.0.0.1;Port=5432;User Id=swik;Password=1234;Database=Luchtkwaliteit;");
                NpgsqlConnection conDataBase = new NpgsqlConnection(connstring);
                try
                {
                    NpgsqlCommand mySqlCmd = conDataBase.CreateCommand();
                    conDataBase.Open();
                    timeread = 0;
                    progressBar1.Value = 0;
                    dateread = trackBar1.Value;
                    maxdate = trackBar2.Value;
                    if (maxdate > dateread) { progressBar1.Maximum = 23 * (maxdate - dateread) * (locread.Length / 6); }
                    progressBar1.Show();
                    chart1.Series.Clear();
                    //checks for selected chart format
                    if (chartselect == "spline chart") { createspline(); }
                    if (chartselect == "pie chart") { createpie(); }
                    if (chartselect == "map")
                    {
                        while (locread.Length > 5)
                        {
                            if (locread.Length > 6) { locreadpart = locread.Remove(0, 6); locread = locread.Remove(0, 6); } else { locreadpart = locread; }
                            gMapControl1.Show();
                            createmap();
                            //links the checkbox to the location methods
                            if (locreadpart == "482MRK") { Markweg(50, Color.Red, 3); }
                            if (locreadpart == "483A15") { A15botlek(50, Color.Red, 3); }
                            if (locreadpart == "485HGV") { Hoogvliet(50, Color.Red, 3); }
                            if (locreadpart == "486PNS") { Pernis(50, Color.Red, 3); }
                            if (locreadpart == "487RPW") { Pleinweg(50, Color.Red, 3); }
                            if (locreadpart == "489RID") { A16ridderkerk(50, Color.Red, 3); }
                            if (locreadpart == "491RDO") { Overschie(50, Color.Red, 3); }
                            if (locreadpart == "493RDS") { Rotterdamnoord(50, Color.Red, 3); }
                            if (locreadpart == "494SDM") { Schiedam(50, Color.Red, 3); }
                            if (locreadpart == "495MSL") { Maassluis(50, Color.Red, 3); }
                        }
                    }
                        progressBar1.Hide();
                }
                catch (Exception msg) { MessageBox.Show(msg.ToString()); throw; }
            }


        }
    

    }
}
