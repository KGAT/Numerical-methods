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
        //Также нужен список точек для графика
        //Плюс нужны поля, которые будут в таблице
        public void Init(Point _currP, int _a, int _maxsteps, int _T, double _h, double _eps, double eBorder)
        {

        }

        public bool NeedStop()
        {
            return false;
        }
    }
}
