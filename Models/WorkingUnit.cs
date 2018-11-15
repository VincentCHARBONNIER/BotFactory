using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit
    {
        // Propriétés.
        public Coordinates ParkingPos { get; set; }

        public Coordinates WorkingPos { get; set; }

        public bool IsWorking { get; set; }

        // Constructeurs.
        public WorkingUnit()
        {

        }

        public WorkingUnit(string name) 
            : base (name)
        {

        }

        public WorkingUnit(double buildTime, string name, double speed)
            : base(buildTime, name, 1)
        {

        }
        public WorkingUnit(double buildTime, double vitesse)
           : base(buildTime, 1)
        {

        }

        public WorkingUnit(Coordinates parkingPos, Coordinates workingPos, bool isWorking)
        {
            this.ParkingPos = parkingPos;
            this.WorkingPos = workingPos;
            this.IsWorking = isWorking;

        }

        // Méthodes.
        public virtual async Task<bool> WorkBegins()
        {
            try
            {
                this.OnStatusChanged(new StatusChangedEventArgs("Je suis en pleine forme, je vais travailler go go go !"));

                bool result = await this.Move(this.CurrentPos, this.WorkingPos);

                this.CurrentPos.X = this.WorkingPos.X;
                this.CurrentPos.Y = this.WorkingPos.Y;
                this.IsWorking = true;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> WorkEnds()
        {
            try
            {
                this.OnStatusChanged(new StatusChangedEventArgs("Je n'ai plus de batterie, je vais me recharger et dormir !"));

                bool result = await this.Move(this.CurrentPos, this.ParkingPos);
                
                this.CurrentPos.X = this.ParkingPos.X;
                this.CurrentPos.Y = this.ParkingPos.Y;
                this.IsWorking = false;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
