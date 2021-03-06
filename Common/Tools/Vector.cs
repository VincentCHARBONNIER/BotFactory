﻿using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector : IVector
    {
        // Propriétées.
        public double X { get; set; }
        public double Y { get; set; }

        // Constructeurs.
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // Méthodes.
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            return new Vector(Math.Abs(end.X - begin.X), Math.Abs(end.Y - begin.Y));
        }

        public static double Length(Vector vector)
        {
            // Formule : RacineCarrée ((Xb-Xa)² + (Yb-Ya)²)
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }
    }
}
