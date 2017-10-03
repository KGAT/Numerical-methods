using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Method
    {
        Point currP;
        private int a; //параметр пропорциональности а
        private int maxsteps;//максимальное количество шагов
        private double T; //начальная температура
        private double h; //шаг
        private double eps; //контроль шага
        private double eBorder; //контроль выхода на границу
        //Вообще ещё нужно, чтобы в ходе работы метода он выводил сразу в таблицу необходимые данные
        private List<Point> points; //массив точек для отрисовки графика
        private List<InfoTable> table_data; //массив данных таблицы
        private int step_counter; // Подсчёт шагов
        private int pluscorr_Step;
        private int minuscorr_Step;


        public void Init(Point _currP, int _a, int _maxsteps, int _T, double _h, double _eps, double eBorder,
            int _plus_corr_Step, int _minus_corr_Step) //Тихончук
        {

        }

        public void Start()
        {
            while (!NeedStop())
            {
                double _h = h; // тот h, который нужен для получения новой точки
                Point newpoint = MakeStep(currP, h);
                Point halfpoint = HalfPointM(currP, h);
                double s = Math.Abs(GetS(halfpoint, newpoint));
                double err_l = Math.Abs(Math.Pow(2, 2) * s);
                double corr_v = GetVCorrect(currP, s);
                if (s <= eps / (Math.Pow(2, 2)))
                {
                    currP = newpoint;
                    h = 2 * h;
                    pluscorr_Step++;
                    points.Add(newpoint);
                }
                else if( s > eps )
                {
                    h = h / 2;
                    minuscorr_Step++;
                }
                else
                {
                    currP = newpoint;
                    points.Add(newpoint);
                }
                table_data.Add(new InfoTable(step_counter, _h, currP, halfpoint.V, currP.V - halfpoint.V,
                    s, corr_v,  pluscorr_Step, minuscorr_Step));
                step_counter++;
            }
        }

        private double GetVCorrect(Point p, double s) //Гаврилов
        {
            return 1.0f;
        }
        private double GetS(Point p1, Point p2)  //Гаврилов
        {
            return 1.0f;
        }
        private Point HalfPointM(Point p, double h) //Гаврилов
        {
            return new Point(0,0);
        }

        public bool NeedStop() //Кильдишев
        {
            bool stop = false;
            if (step_counter >= maxsteps) //Вот тут не до конца, нужно понять, как правильно сделать
                stop = !stop;
            return stop;
        }

        private Point MakeStep(Point p, double h) //Кильдишев
        {
            double pX = GetNextX(p.X, h);
            double pV = GetNextU(p.X,p.V, h);
            return new Point(pX, pV);
        }
        private double GetNextX(double x, double h) //Тихончук
        {
            return 1.0f;
        }

        private double GetNextU(double x, double u, double h) //Тихончук
        {
            return 1.0f;
        }
       

        public List<InfoTable> GetMetodInfos() //сделано
        {
            return table_data;
        }
        public List<Point> GetPoints() //сделано
        {
            return points;
        }

    }
}
