using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T_800 : WorkingUnit
    {
        // Constructeur
        public T_800() : base(3, "T-800", 10)
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
