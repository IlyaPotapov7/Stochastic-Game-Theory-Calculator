using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stochastic_Game_Theory_Calculator.Entities
{
    public class Point
    {
        private Vector position;
        private double thickness;

        public Point(Vector position)
        {
            this.Position = position;  
            this.Thickness = thickness;
        }

        public Vector Position 
        {
            get { return position; }
            set { position = value; }
        }
        public double Thickness 
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Point()
        {
            this.Position = Vector.Zero;
            this.Thickness = 0.0;
        }

    }
}
