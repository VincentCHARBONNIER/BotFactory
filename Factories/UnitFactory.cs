using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        // Propriétées.
        public int QueueCapacity { get; private set; }
        public int StorageCapacity { get; private set; }
        public Queue<IFactoryQueueElement> Queue { get; private set; }
        public List<ITestingUnit> Storage { get; private set; }

        public event EventHandler FactoryProgress;

        public static object thisLock = new object();

        public TimeSpan QueueTime { get; set; }

        // Propriétées calculées.
        public int QueueFreeSlots
        {
            get
            {
                return QueueCapacity - Queue.Count;
            }
        }

        public int StorageFreeSlots
        {
            get
            {
                return StorageCapacity - Storage.Count;
            }
        }

        // Constructeurs.
        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            this.QueueCapacity = queueCapacity;
            this.StorageCapacity = storageCapacity;
            this.Queue = new Queue<IFactoryQueueElement>();
            this.Storage = new List<ITestingUnit>();
        }

        // Méthodes.
        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingCor, Coordinates workingCor)
        {
            try
            {
                if (this.QueueCapacity < this.Queue.Count && this.StorageCapacity < this.Storage.Count)
                {
                    return false;
                }

                OnStatusChangedFactory(new StatusChangedEventArgs("Ajoutons le robot " + name + " à la file d'attente !"));
                FactoryQueueElement commande = new FactoryQueueElement(model, name, parkingCor, workingCor);

                if (null == commande)
                {
                    return false;
                }

                Queue.Enqueue(commande);
                OnStatusChangedFactory(new StatusChangedEventArgs("C'est chose faite, continuons maintenant !"));

                lock (thisLock)
                {
                    ITestingUnit robotToTest = (ITestingUnit)Activator.CreateInstance(commande.Model);

                    robotToTest.Name = name;
                    robotToTest.Model = model.Name;
                    robotToTest.ParkingPos = parkingCor;
                    robotToTest.WorkingPos = workingCor;

                    OnStatusChangedFactory(new StatusChangedEventArgs("Maintenant, le robot est prêt à être testé !"));
                    Monitor.Wait(thisLock, Convert.ToInt32(robotToTest.BuildTime) * 1000);
                    Storage.Add(robotToTest);
                    Queue.Dequeue();
                    QueueTime += TimeSpan.FromMilliseconds(robotToTest.BuildTime);
                    OnStatusChangedFactory(new StatusChangedEventArgs("Let's go !"));
                    Monitor.Pulse(thisLock);

                    return true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
