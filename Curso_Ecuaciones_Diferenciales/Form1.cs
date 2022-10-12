using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Legends;
namespace Curso_Ecuaciones_Diferenciales
{
    public partial class Form1 : Form
    {
        double P(double P0, double k, double t) => P0 * Math.Exp(-k * t);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            //Acquire data
            double k, P0, T, dt;
            k = double.Parse(tbValorK.Text);
            P0 = double.Parse(tbCInicial.Text);
            T = double.Parse(tbTiempo.Text);
            dt = double.Parse(tbIncremento.Text);
            //Create Plot
            PlotModel Grafica = plotView1.ActualModel == null ? new PlotModel() : plotView1.ActualModel;
            LineSeries Poblacion = new LineSeries();
            for (double t = 0; t <= T; t += dt)
                Poblacion.Points.Add(new DataPoint(t, P(P0, k, t)));
            Grafica.Series.Add(Poblacion);
            //Add to datagridview
            dataGridView1.Rows.Add(new object[] { "", k, P0 });
            plotView1.Model = Grafica;
            plotView1.InvalidatePlot(true);
        }
    }
}
