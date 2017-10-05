using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Dtos;
using LiveCharts.Wpf;
using Brushes = System.Drawing.Brushes;


namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Температура тела",
            });
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Время"
            });

            

        }
        List<Point> copy; 
        private void button1_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series.Clear();
            Method RK = new Method();
            double V0 = Convert.ToDouble(textBox1.Text);
            Point p = new Point(0, V0);
            int _a = Convert.ToInt32(textBox3.Text);
            int _maxsteps = Convert.ToInt32(textBox6.Text);
            double _T = Convert.ToDouble(textBox2.Text);
            double _h = Convert.ToDouble(textBox4.Text);
            double _eps = Convert.ToDouble(textBox5.Text);
            double _eBorder = Convert.ToDouble(textBox7.Text);
            RK.Init(p, _a, _maxsteps, _T, _h, _eps, _eBorder, 0, 0);
            RK.Start();

            dataGridView1.RowCount = RK.GetMetodInfos().Count;
            dataGridView1.ColumnCount = 10;

            int n = RK.GetMetodInfos().Count;
            dataGridView1.Columns[0].HeaderText = "№";
            for (int i = 0; i < n; i++)
                dataGridView1[0, i].Value = i;

            dataGridView1.Columns[1].HeaderText = "h_i-1";
            for (int i = 0; i < n; i++)
                dataGridView1[1, i].Value = RK.GetMetodInfos()[i].integr_step;

            dataGridView1.Columns[2].HeaderText = "x_i";
            for (int i = 0; i < n; i++)
                dataGridView1[2, i].Value = RK.GetMetodInfos()[i].point.X;

            dataGridView1.Columns[3].HeaderText = "v_i";
            for (int i = 0; i < n; i++)
                dataGridView1[3, i].Value = RK.GetMetodInfos()[i].point.V;

            dataGridView1.Columns[5].HeaderText = "S";
            for (int i = 0; i < n; i++)
                dataGridView1[5, i].Value = RK.GetMetodInfos()[i].S;

            dataGridView1.Columns[6].HeaderText = "e";
            for (int i = 0; i < n; i++)
                dataGridView1[6, i].Value = RK.GetMetodInfos()[i].err_loc;

            dataGridView1.Columns[7].HeaderText = "v_corr";
            for (int i = 0; i < n; i++)
                dataGridView1[7, i].Value = RK.GetMetodInfos()[i].corr_V;

            dataGridView1.Columns[8].HeaderText = "Up_step";
            for (int i = 0; i < n; i++)
                dataGridView1[8, i].Value = RK.GetMetodInfos()[i].plus_corr_Step;

            dataGridView1.Columns[9].HeaderText = "Down_step";
            for (int i = 0; i < n; i++)
                dataGridView1[9, i].Value = RK.GetMetodInfos()[i].minus_corr_Step;
            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Численное решение",
                Values = new ChartValues<ObservablePoint>(RK
         .GetPoints()
         .Select(_ => new ObservablePoint(_.X, _.V))),
                PointGeometrySize = 5
            });
            copy = RK.GetPoints();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            TrueSolution true100 = new TrueSolution(copy,Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox3.Text),
                Convert.ToDouble(textBox2.Text));
            true100.BuildSolution();
            dataGridView1.Columns[4].HeaderText = "u_i";
            for (int i = 0; i < copy.Count; i++)
            {
                dataGridView1[4, i].Value = true100.GetPoints()[i].V;
            }
            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Точное решение",
                Values = new ChartValues<ObservablePoint>(true100
.GetPoints()
.Select(_ => new ObservablePoint(_.X, _.V))),
                PointGeometrySize = 5
            });


        }
    }
}
