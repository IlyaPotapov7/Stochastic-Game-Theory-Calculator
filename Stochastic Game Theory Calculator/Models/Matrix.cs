using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stochastic_Game_Theory_Calculator.Models
{
    public class Matrix
    {
        public int rows { get; set; }
        public int cols { get; set; }
        public string[,] payoffs { get; set; }
        public string[] RowStrategies { get; set; }
        public string[] ColStrategies { get; set; }

        public float X { get; set; } = 50;
        public float Y { get; set; } = 50;

        public Matrix defaultMatrix()
        {
            rows = 2;
            cols = 2;
            payoffs[2, 2] = "2,2";
            payoffs[2, 3] = "0,4";
            payoffs[3, 2] = "4,0";
            payoffs[3, 3] = "3,3";
            RowStrategies = new string[] { "Cooperate", "Defect" };
            ColStrategies = new string[] { "Cooperate", "Defect" };
            return this;

        }

    }
}
