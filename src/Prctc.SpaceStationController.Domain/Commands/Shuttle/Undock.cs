using System;
using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Commands
{
    public class Undock : ICommand
    {
        private readonly Station _station;
        private readonly Shuttle _shuttle;
        public Undock(Station station, Shuttle shuttle)
        {
            _station = station;
            _shuttle = shuttle;
        }
        public void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            _station.UndockShuttle(_shuttle);
            onSuccess(new CommandResult { IsSuccess = true, ShuttleName = $"{_shuttle.Name}({_shuttle.Id})" });
        }
    }
}