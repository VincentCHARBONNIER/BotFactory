using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        //Propriétées.
        public double X { get; set; }

        public double Y { get; set; }

        // Constructeurs.
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

        // Méthodes.
        public override bool Equals(object obj)
        {
            if (null == obj || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Coordinates point = (Coordinates)obj;
            return (this.X.Equals(point.X) && this.Y.Equals(point.Y));

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}