using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class TrueSolution
    {
        private List<Point> points;
        private int a;
        private double T;
        private double U0;


        public TrueSolution(List<Point> entr,double _U0,int _a, double _T)
        {
            points = entr;
            U0 = _U0;
            a = _a;
            T = _T;
        }
        private double GetUValue(double x)
        {
            double C = U0- T;
            return (C*Math.Exp(-a* x) + T);
        }

        public void BuildSolution()
        {
            double x = points[0].X;
            double u = U0;
            points[0].V = u;
            for (int i = 1; i < points.Count; i++) 
            {
                x = points[i].X;
                u = GetUValue(x);
                points[i].V = u;
            }
        }

        public List<Point> GetPoints()
        {
            return points;
        }

    }
}
