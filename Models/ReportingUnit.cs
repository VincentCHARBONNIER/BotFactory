using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {
        // Propriétée.
        public event EventHandler UnitStatusChanged;

        // Constructeur.
        public ReportingUnit()
        {

        }

        public ReportingUnit(double buildTime)
            : base(buildTime)
        {

        }

        // Méthode.
        public virtual void OnStatusChanged (StatusChangedEventArgs e)
        {
            if (this.UnitStatusChanged != null)
            {
                UnitStatusChanged(this, e);
            }
        }
    }
}
