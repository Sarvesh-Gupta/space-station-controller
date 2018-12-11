using System;

namespace Prctc.SpaceStationController.Core
{
    public interface ICommand
    {
         void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail);
    }
}