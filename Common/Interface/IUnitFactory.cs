using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;

namespace BotFactory.Common.Interface
{
    public interface IUnitFactory
    {
        int QueueCapacity { get; set; }
        int StorageCapacity { get; set; }
        Queue<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }

        int QueueFreeSlots { get; set; }

        int StorageFreeSlots { get; set; }

        TimeSpan QueueTime { get; set; }

        event EventHandler FactoryProgress;


        bool AddWorkableUnitToQueue(Type model, string Name, Coordinates parkingCor, Coordinates workingCor);
    }
}