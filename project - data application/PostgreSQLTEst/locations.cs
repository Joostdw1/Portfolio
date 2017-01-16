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
        //Every location has its own method with its own transparency, color and stroke
        public void Markweg(int alpha, Color color, int stroke)
        {
            GMapOverlay polyMarkweg = new GMapOverlay("Markweg");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.9410902617023, 4.08227920532227));
            points.Add(new PointLatLng(51.9337877891876, 4.14030075073242));
            points.Add(new PointLatLng(51.9811797524254, 4.14836883544922));
            points.Add(new PointLatLng(51.9918571817366, 4.11918640136719));
            points.Add(new PointLatLng(51.9678558261417, 4.09189224243164));
            points.Add(new PointLatLng(51.9410902617023, 4.08227920532227));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyMarkweg.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyMarkweg);
        }

        public void A15botlek(int alpha, Color color, int stroke)
        {
            GMapOverlay polyA15botlek = new GMapOverlay("A15 Botlek");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.8677470472371, 4.35393333435059));
            points.Add(new PointLatLng(51.8697079536895, 4.37084197998047));
            points.Add(new PointLatLng(51.8697079536895, 4.38981056213379));
            points.Add(new PointLatLng(51.8811007184086, 4.39032554626465));
            points.Add(new PointLatLng(51.8789813528329, 4.33822631835938));
            points.Add(new PointLatLng(51.8691249904312, 4.3450927734375));
            points.Add(new PointLatLng(51.8677470472371, 4.35393333435059));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyA15botlek.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyA15botlek);
        }
        public void Pernis(int alpha, Color color, int stroke)
        {
            GMapOverlay polyPernis = new GMapOverlay("Pernis");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.8816305441918, 4.37710762023926));
            points.Add(new PointLatLng(51.8964631310589, 4.3710994720459));
            points.Add(new PointLatLng(51.8964631310589, 4.3710994720459));
            points.Add(new PointLatLng(51.8916960476969, 4.3989086151123));
            points.Add(new PointLatLng(51.8827431580114, 4.405517578125));
            points.Add(new PointLatLng(51.8809947525026, 4.39041137695313));
            points.Add(new PointLatLng(51.8816305441918, 4.37710762023926));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyPernis.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyPernis);
        }
        public void Hoogvliet(int alpha, Color color, int stroke)
        {
            GMapOverlay polyHoogvliet = new GMapOverlay("Hoogvliet");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.8677470472371, 4.35384750366211));
            points.Add(new PointLatLng(51.8697079536895, 4.37118530273438));
            points.Add(new PointLatLng(51.8615987863345, 4.38294410705566));
            points.Add(new PointLatLng(51.8542833813926, 4.37556266784668));
            points.Add(new PointLatLng(51.8605386564162, 4.34474945068359));
            points.Add(new PointLatLng(51.8677470472371, 4.35384750366211));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyHoogvliet.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyHoogvliet);
        }
        public void Pleinweg(int alpha, Color color, int stroke)
        {
            GMapOverlay polyPleinweg = new GMapOverlay("Pleinweg");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.8910339127872, 4.46542739868164));
            points.Add(new PointLatLng(51.8887296072523, 4.50212001800537));
            points.Add(new PointLatLng(51.9001175524839, 4.49692726135254));
            points.Add(new PointLatLng(51.8993760997099, 4.47662830352783));
            points.Add(new PointLatLng(51.8910339127872, 4.46542739868164));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyPleinweg.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyPleinweg);
        }
        public void A16ridderkerk(int alpha, Color color, int stroke)
        {
            GMapOverlay polyA16ridderkerk = new GMapOverlay("A16 Ridderkerk");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.8647790262026, 4.57383155822754));
            points.Add(new PointLatLng(51.8421414254286, 4.59271430969238));
            points.Add(new PointLatLng(51.8538062484514, 4.61777687072754));
            points.Add(new PointLatLng(51.8704498959988, 4.603271484375));
            points.Add(new PointLatLng(51.8735765183919, 4.58078384399414));
            points.Add(new PointLatLng(51.8647790262026, 4.57383155822754));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyA16ridderkerk.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyA16ridderkerk);
        }
        public void Schiedam(int alpha, Color color, int stroke)
        {
            GMapOverlay polySchiedam = new GMapOverlay("Schiedam");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.908802230877, 4.38079833984375));
            points.Add(new PointLatLng(51.9048837424215, 4.41204071044922));
            points.Add(new PointLatLng(51.9142028302891, 4.42783355712891));
            points.Add(new PointLatLng(51.9240493101871, 4.41890716552734));
            points.Add(new PointLatLng(51.9274368469136, 4.39693450927734));
            points.Add(new PointLatLng(51.9226730503612, 4.37959671020508));
            points.Add(new PointLatLng(51.908802230877, 4.38079833984375));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polySchiedam.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polySchiedam);
        }
        public void Maassluis(int alpha, Color color, int stroke)
        {
            GMapOverlay polyMaassluis = new GMapOverlay("Maassluis");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.9283366183815, 4.22887802124023));
            points.Add(new PointLatLng(51.9357458151035, 4.25479888916016));
            points.Add(new PointLatLng(51.9246315612571, 4.28080558776855));
            points.Add(new PointLatLng(51.9121379719106, 4.26475524902344));
            points.Add(new PointLatLng(51.9171675890901, 4.2392635345459));
            points.Add(new PointLatLng(51.9283366183815, 4.22887802124023));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyMaassluis.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyMaassluis);
        }
        public void Rotterdamnoord(int alpha, Color color, int stroke)
        {
            GMapOverlay polyRotterdamnoord = new GMapOverlay("Rotterdam Noord");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.9329410488144, 4.4304084777832));
            points.Add(new PointLatLng(51.9244727662598, 4.45289611816406));
            points.Add(new PointLatLng(51.9270134188046, 4.48328018188477));
            points.Add(new PointLatLng(51.9339994717844, 4.50439453125));
            points.Add(new PointLatLng(51.946592788943, 4.49460983276367));
            points.Add(new PointLatLng(51.9501902302538, 4.47658538818359));
            points.Add(new PointLatLng(51.9473334622144, 4.45461273193359));
            points.Add(new PointLatLng(51.9329410488144, 4.4304084777832));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyRotterdamnoord.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyRotterdamnoord);
        }
        public void Overschie(int alpha, Color color, int stroke)
        {
            GMapOverlay polyOverschie = new GMapOverlay("Overschie");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(51.9472805573864, 4.45452690124512));
            points.Add(new PointLatLng(51.928760034007, 4.42268371582031));
            points.Add(new PointLatLng(51.9489205780359, 4.40491676330566));
            points.Add(new PointLatLng(51.961668370623, 4.42946434020996));
            points.Add(new PointLatLng(51.9580189579793, 4.44723129272461));
            points.Add(new PointLatLng(51.9472805573864, 4.45452690124512));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(alpha, color));
            polygon.Stroke = new Pen(color, stroke);
            polyOverschie.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyOverschie);
        }
    }
}
