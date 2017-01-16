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

        public void createmap()
        {
            string connstring = String.Format("Server=127.0.0.1;Port=5432;User Id=swik;Password=1234;Database=Luchtkwaliteit;");
            NpgsqlConnection conDataBase = new NpgsqlConnection(connstring);
            NpgsqlCommand mySqlCmd = conDataBase.CreateCommand();
            conDataBase.Open();
            gMapControl1.Show();
            while (locread.Length > 5)
            {
                dateread = trackBar1.Value;
                maxdate = trackBar2.Value;
                if (locread.Length > 6) { locreadpart = locread.Remove(0, locread.Length - 6); } else { locreadpart = locread; }
                chart1.Series.Add(locreadpart);
                chart1.Series[locreadpart].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string datum = "";
                string tijd = "";
                double average = 0;
                int averagecounter = 0;
                while (dateread != maxdate)
                {
                    if (timeread < 10) { timezero = "0"; } else { timezero = ""; }
                    if (dateread < 10) { datezero = "0"; } else { datezero = ""; }
                    datum = "2014-01-" + datezero + dateread.ToString();
                    tijd = timezero + timeread.ToString() + ":00:00";
                    string locatie = "meetlocatie = '" + locreadpart + "' AND ";
                    mySqlCmd.CommandText = "SELECT " + yread + " FROM luchtdata WHERE " + locatie + "datum = '" + datum + "' AND tijd = '" + tijd + "';";
                    double returnvalue = Convert.ToDouble(mySqlCmd.ExecuteScalar());
                    average = average + returnvalue;
                    averagecounter = averagecounter + 1;
                    progressBar1.Value = progressBar1.Value + 1;
                    dateread = dateread + 1; timeread = 0;
                }
                //chart1.Series[locreadpart].Points.AddXY(locreadpart, (average / averagecounter));
                locread = locread.Remove(locread.Length - 6, 6);
            }


        }
    }
}
