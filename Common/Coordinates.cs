using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Coordinates()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Coordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coordinates point = (Coordinates)obj;
                return (this.X.Equals(point.X) && this.Y.Equals(point.Y));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}