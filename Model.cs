using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Calc
{
    class Model
    {
        double argument1, argument2;

        public double Argument1
        {
            set { argument1 = value; }
        }

        public double Argument2
        {
            set { argument2 = value; }
        }

        public double Sum()
        {
            return argument1 + argument2;
        }

        public double Sub()
        {
            return argument1 - argument2;
        }

        public double Mult()
        {
            return argument1 * argument2;
        }

        public double Div()
        {
            return argument1 / argument2;   
        }

    }
}
