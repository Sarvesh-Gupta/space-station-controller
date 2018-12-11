using System;
using System.Collections.Concurrent;

namespace Prctc.SpaceStationController.Core
{
    public class StationController
    {
        private ConcurrentQueue<ICommand> _commands;

        public StationController()
        {
            _commands = new ConcurrentQueue<ICommand>();
        }

        public void ExecuteCommand(ICommand command, Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            _commands.Enqueue(command);
            ICommand commandToExecute;
            _commands.TryDequeue(out commandToExecute);
            commandToExecute.Execute(onSuccess, onFail);
        }
    }
}