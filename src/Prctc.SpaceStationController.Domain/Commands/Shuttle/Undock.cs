using System;
using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Commands
{
    public class Undock : ICommand
    {
        public Undock(Shuttle shuttle)
        {
            
        }
        public void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            throw new System.NotImplementedException();
        }
    }
}