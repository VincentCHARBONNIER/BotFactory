using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {
        // Propriétées.
        public string Name { get; set; }

        public Type Model { get; set; }

        public Coordinates ParkingPos { get; set; }

        public Coordinates WorkingPos { get; set; }

        // Constructeurs.
        public FactoryQueueElement()
        {

        }
        public FactoryQueueElement(string name, Type model, Coordinates parkingPos, Coordinates workingPos)
        {
            this.Name = name;
            this.Model = model;
            this.ParkingPos = parkingPos;
            this.WorkingPos = workingPos;
        }
    }
}
