using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit
    {
        public event EventHandler UnitStatusChanged;

        public ReportingUnit()
        {

        }

        public virtual void OnStatusChanged (StatusChangedEventArgs e)
        {
            if (this.UnitStatusChanged != null)
            {
                UnitStatusChanged(this, e);
            }
        }
    }
}
