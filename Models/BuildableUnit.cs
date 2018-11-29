using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        // Propriétées.
        public double BuildTime { get; set; }
        public string Model { get; set; }

        // Constructeurs.
        public BuildableUnit()
        {
            this.BuildTime = 5;
        }

        public BuildableUnit (double buildTime = 5)
        {
            this.BuildTime = buildTime;
        }
    }
}
