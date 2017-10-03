using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class InfoTable
    {
        public int iter;
        public double integr_step;
        public double X;
        public double V;
        public double double_V;
        public double dV;
        public double S;
        public double corr_V;
        public double res_V;
        public int plus_corr_Step;
        public int minus_corr_Step;

        public InfoTable(int _iter, double _integr_step, double _X, double _V, double _double_V,
            double _dV, double _S, double _corr_V, double _res_V, int _plus_corr_Step, int _minus_corr_Step)
        {
            iter = _iter;
            integr_step = _integr_step;
            X = _X;
            V = _V;
            double_V = _double_V;
            dV = _dV;
            S = _S;
            corr_V = _corr_V;
            res_V = _res_V;
            plus_corr_Step = _plus_corr_Step;
            minus_corr_Step = _minus_corr_Step;
        }
    }
}
