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

        public void traffic()
        {
            string connstring = String.Format("Server=127.0.0.1;Port=5432;User Id=swik;Password=1234;Database=Luchtkwaliteit;");
            NpgsqlConnection conDataBase = new NpgsqlConnection(connstring);
            NpgsqlCommand mySqlCmd = conDataBase.CreateCommand();
            conDataBase.Open();
            chart1.Show();
            chart1.Series.Clear();
            chart1.Series.Add("traffic intensity");
            while (locread.Length > 5)
            {
                int timeread = 0;
                int maxtime = 24;
                string timezero = "0";
                string locreadpart = locread;
                label3.Text = locread;
                while (timeread != maxtime)
                    chart1.Series[locreadpart].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                {
                    if (timeread < 10) { timezero = "0"; }
                    else { timezero = ""; }
                    string tijd = timezero + timeread.ToString() + ":00";
                    if (locread.Length > 6) { locreadpart = locread.Remove(0, 6); } else { locreadpart = locread; }
                    string locatie = "meetlocatie = '" + locreadpart + "' AND ";
                    mySqlCmd.CommandText = "SELECT intensiteit FROM verkeersdata WHERE " + locatie + "tijd = '" + tijd + "';";
                    int returnvalue = Convert.ToInt32(mySqlCmd.ExecuteScalar());
                    chart1.Series[locreadpart].Points.AddXY(tijd, returnvalue.ToString());
                }
                locread = locread.Remove(locread.Length - 6, 6);
            }
        }
    }
}
