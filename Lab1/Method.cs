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
        private double a; //параметр пропорциональности а
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
       


        public void Init(Point _currP, int _a, int _maxsteps, int _T, double _h, double _eps, double _eBorder,
            int _plus_corr_Step, int _minus_corr_Step) //Сделано
        {
            currP = _currP;
            a = _a;
            maxsteps = _maxsteps;
            T = _T;
            h = _h;
            eps = _eps;
            pluscorr_Step = _plus_corr_Step;
            minuscorr_Step = _minus_corr_Step;
        }

        public void Start()
        {
            while (!NeedStop())
            {
                double _h = h; // тот h, который нужен для получения новой точки
                Point newpoint = MakeStep(currP, h);
                Point halfpoint = HalfPointM(currP, h);
                double s = Math.Abs(GetS(newpoint, halfpoint)); // здесь поменял местами точки
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

        private double GetVCorrect(Point p, double s) //Сделано
        {
            return p.V + Math.Pow(2, 2) * s; 
        }
        private double GetS(Point p1, Point p2)  //Сделано  p2 - это Vn с двумя крышками , p1 - Vn
        {
            return (p2.V-p1.V)/(2.0*2.0-1.0);
        }
        private Point HalfPointM(Point p, double h) //Сделано
        {
            Point _p = MakeStep(p, h / 2.0);
            return MakeStep(_p,h/2.0);
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
            double pV = GetNextV(p.X,p.V, h);
            return new Point(pX, pV);
        }
        private double GetNextX(double x, double h) //Сделано
        {
            return (x+h);
        }

        private double GetNextV(double x, double v, double h) //Сделано
        {
            if (v < 0)
            {
                return 0;
            }
            double F = f(x + h / 2.0, v + (h / 2.0) * f(x, v));
            return v + h * F;
        }

        private double f(double x, double u)  //Вычисление правой части д.у
        {
            return (-1.0*a*(u-T));
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
