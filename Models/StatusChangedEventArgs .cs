using BotFactory.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        // Propriétée.
        public string NewStatus { get; set; }

        // Constructeur.
        public StatusChangedEventArgs(string newStatus)
        {
            this.NewStatus = newStatus;
        }
    }
}
