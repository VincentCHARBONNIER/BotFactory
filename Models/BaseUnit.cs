using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit
    {
        // Propriétés.
        public string Name { get; set; }

        public double Speed { get; set; }

        public Coordinates CurrentPos { get; set; }

        // Constructeurs.
        public BaseUnit()
        {
            this.Speed = 1;
        }

        public BaseUnit(string name)
        {
            this.Name = name;
            this.Speed = 1;
        }

        public BaseUnit(string name, double speed = 1)
        {
            this.Name = name;
            this.Speed = speed;
            this.CurrentPos = new Coordinates(0,0);
        }

        public BaseUnit(double buildTime, double vitesse = 1)
            : base(buildTime)
        {
            this.Speed = vitesse;
            this.CurrentPos = new Coordinates(0, 0);
        }

        public BaseUnit(double buildTime, string name, double speed = 1)
            : base(buildTime)
        {
            this.Name = name;
            this.Speed = speed;
            this.CurrentPos = new Coordinates(0, 0);
        }

        // Méthodes.
        public async Task<bool> Move (Coordinates beginPos, Coordinates endPos)
        {
            try
            {
                if (!beginPos.Equals(endPos))
                {
                    double distance = Vector.Length(Vector.FromCoordinates(beginPos, endPos));
                    int time = Convert.ToInt32(distance/ this.Speed);

                    // Add delay & conversion secondes en millisecondes.
                    await Task.Delay(time*1000);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false ;
            }
        }
    }
}
