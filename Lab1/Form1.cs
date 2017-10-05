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
            Method RK = new Method();
            Point p = new Point(1,1);
            RK.Init(p, 1, 5000,2, 0.001, 0.0001, 0.01, 0, 0);
            RK.Start();

            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 10;
            
            /*
             dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
             dataGridView1.AutoResizeColumns();
             dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
             dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);*/

            int n = 9;

            dataGridView1[0, 0].Value = "№";
            for (int i = 1; i <= n; i++)
                dataGridView1[0, i].Value = i;

            dataGridView1[1, 0].Value = "h";
            for (int i = 0; i < n; i++)
                dataGridView1[1, i+1].Value = RK.GetMetodInfos()[i].integr_step;

            dataGridView1[2, 0].Value = "half_v";
            for (int i = 0; i < n; i++)
                dataGridView1[2, i+1].Value = RK.GetMetodInfos()[i].half_V;

            //и так далее для других выходных данных
   

        }

    
    }
}
