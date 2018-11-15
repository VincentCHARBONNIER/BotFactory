using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        // Propriétées.
        public int QueueCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public Queue<IFactoryQueueElement> Queue { get; set; }
        public List<ITestingUnit> Storage { get; set; }

        public event EventHandler FactoryProgress;

        // Constructeurs.
        public UnitFactory (int queueCapacity, int storageCapacity)
        {
            this.QueueCapacity = queueCapacity;
            this.StorageCapacity = storageCapacity;
            this.Queue = new Queue<IFactoryQueueElement>();
            this.Storage = new List<ITestingUnit>();
        }

        // Méthodes.
        public bool AddWorkableUnitToQueue (Type model, string Name, Coordinates parkingCor, Coordinates workingCor)
        {
            try
            {
                // A modifier.
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void OnStatusChangedFactory(StatusChangedEventArgs e)
        {
            if (this.FactoryProgress != null)
            {
                FactoryProgress(this, e);
            }
        }
    }
}
