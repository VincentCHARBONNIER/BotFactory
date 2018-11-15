using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit
    {
        // Constructeur.
        public R2D2() : base(1.5, "R2D2", 5.5)
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
