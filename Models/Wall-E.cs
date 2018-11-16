using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class Wall_E : WorkingUnit, IWall_E, ITestingUnit
    {
        // Constructeur.
        public Wall_E() : base(2, "Wall_E", 4)
        {

        }

        // Méthodes surchargées.
        public override async Task<bool> WorkBegins()
        {
            return await base.WorkBegins();
        }

        public override async Task<bool> WorkEnds()
        {
            return await base.WorkEnds();
        }
    }
}
