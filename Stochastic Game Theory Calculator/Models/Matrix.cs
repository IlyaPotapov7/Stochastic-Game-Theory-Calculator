using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stochastic_Game_Theory_Calculator;

namespace Stochastic_Game_Theory_Calculator.Models
{
    public class Matrix
    {
        public int rows { get; set; }
        public int cols { get; set; }
        public string[,] payoffs { get; set; }
        public string[] RowStrategies { get; set; }
        public string[] ColStrategies { get; set; }

        public string[] Players { get; set; }

        public int MatrixID { get; set; }

        public float X { get; set; } = 50;
        public float Y { get; set; } = 50;

        public RectangleF hitbox { get; set; }

        public Matrix defaultMatrix()
        {
            rows = 2;
            cols = 2;
            payoffs = new string[rows, cols];
            payoffs[0, 0] = "2,2";
            payoffs[0, 1] = "4,0";
            payoffs[1, 0] = "0,4";
            payoffs[1, 1] = "3,3";
            RowStrategies = new string[] { "Cooperate", "Defect" };
            ColStrategies = new string[] { "Cooperate", "Defect" };
            Players = new string[] { "Player 1", "Player 2" };
            MatrixID = 0;

            return this;
        }

        public void setMatrixID(int id)
        {
            MatrixID = id;
        }

    }
}
