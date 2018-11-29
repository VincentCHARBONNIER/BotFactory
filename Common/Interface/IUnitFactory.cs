using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;

namespace BotFactory.Common.Interface
{
    public interface IUnitFactory
    {
        int QueueCapacity { get; }
        int StorageCapacity { get;  }
        Queue<IFactoryQueueElement> Queue { get; }
        List<ITestingUnit> Storage { get; }
        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }
        TimeSpan QueueTime { get; set; }
        event EventHandler FactoryProgress;

        bool AddWorkableUnitToQueue(Type model, string Name, Coordinates parkingCor, Coordinates workingCor);
    }
}