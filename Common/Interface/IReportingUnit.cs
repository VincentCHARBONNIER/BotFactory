using BotFactory.Common.Interface;
using System;

namespace BotFactory.Common.Interface
{
    public interface IReportingUnit
    {
        event EventHandler UnitStatusChanged;
    }
}