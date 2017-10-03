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
        private int plus_corr_Step;
        private int minus_corr_Step;


        public void Init(Point _currP, int _a, int _maxsteps, int _T, double _h, double _eps, double eBorder,
            int _plus_corr_Step, int _minus_corr_Step) //Тихончук
        {

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
            return false;
        }

        private Point MakeStep(Point p, double h) //Кильдишев
        {
           
            return new Point(0, 0);
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
