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

    public void createspline()
        {
            string connstring = String.Format("Server=127.0.0.1;Port=5432;User Id=swik;Password=1234;Database=Luchtkwaliteit;");
            NpgsqlConnection conDataBase = new NpgsqlConnection(connstring);
            NpgsqlCommand mySqlCmd = conDataBase.CreateCommand();
            conDataBase.Open();
            if (checkBox1.Checked == true)
            {
                chart1.Series.Add("maximum allowed " + yread);
                chart1.Series["maximum allowed " + yread].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
            chart1.Show();
            while (locread.Length > 5)
            {
                dateread = trackBar1.Value;
                maxdate = trackBar2.Value;
                if (locread.Length > 6) { locreadpart = locread.Remove(0, locread.Length - 6); } else { locreadpart = locread; }
                chart1.Series.Add(locreadpart);
                chart1.Series[locreadpart].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                while (dateread != maxdate)
                {
                    if (timeread < 10) { timezero = "0"; } else { timezero = ""; }
                    if (dateread < 10) { datezero = "0"; } else { datezero = ""; }
                    string datum = "2014-01-" + datezero + dateread.ToString();
                    string tijd = timezero + timeread.ToString() + ":00:00";
                    string locatie = "meetlocatie = '" + locreadpart + "' AND ";
                    mySqlCmd.CommandText = "SELECT " + yread + " FROM luchtdata WHERE " + locatie + "datum = '" + datum + "' AND tijd = '" + tijd + "';";
                    double returnvalue = Convert.ToDouble(mySqlCmd.ExecuteScalar());
                    chart1.Series[locreadpart].Points.AddXY(datum + "\n" + tijd, returnvalue);
                    //checks for selected eelment and adds limit
                    if (yread == "nox" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 300); }
                    if (yread == "no2" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 200); }
                    if (yread == "blackcarbon" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 100); }
                    if (yread == "benzeen" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 5); }
                    if (yread == "tolueen" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 1.29); }
                    if (yread == "ethylbenzeen" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 7.5); }
                    if (yread == "oxyleen" && checkBox1.Checked == true && locread.Length == 6) { chart1.Series["maximum allowed " + yread].Points.AddXY(datum + "\n" + tijd, 0.323); }


                    timeread = timeread + 1;
                    progressBar1.Value = progressBar1.Value + 1;

                    if (timeread == 23) { dateread = dateread + 1; timeread = 0; }
                }
                locread = locread.Remove(locread.Length - 6, 6);
                foreach (object serie in (chart1.Series)) { chart1.Series[(serie.ToString()).Remove(0, 7)].BorderWidth = trackBar3.Value; };
            }


        }
    }
}
