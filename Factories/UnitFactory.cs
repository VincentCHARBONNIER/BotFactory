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
        public int QueueCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public Queue<IFactoryQueueElement> Queue { get; set; }
        public List<ITestingUnit> Storage { get; set; }

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

            set {; }
        }

        public int StorageFreeSlots
        {
            get
            {
                return StorageCapacity - Storage.Count;
            }

            set {; }
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
        public bool AddWorkableUnitToQueue(Type model, string Name, Coordinates parkingCor, Coordinates workingCor)
        {
            try
            {
                OnStatusChangedFactory(new StatusChangedEventArgs("Ajoutons le robot " + Name + " à la file d'attente !"));
                if (this.QueueCapacity > this.Queue.Count && this.StorageCapacity > this.Storage.Count)
                {
                    IFactoryQueueElement commande = new FactoryQueueElement(model, Name, parkingCor, workingCor);

                    if (commande != null)
                    {

                        Queue.Enqueue(commande);
                        OnStatusChangedFactory(new StatusChangedEventArgs("C'est chose faite, continuons maintenant !"));

                        lock (thisLock)
                        {
                            ITestingUnit robotToTest = (ITestingUnit)Activator.CreateInstance(commande.Model, new object[] { });

                            robotToTest.Model = Name;
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
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
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
