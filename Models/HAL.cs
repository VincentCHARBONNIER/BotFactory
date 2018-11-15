using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit, IHAL
    {
        // Constructeur
        public HAL() : base(0.5, "HAL", 7)
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
