
using System;
using System.Collections.Generic;
using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Model;
using Prctc.SpaceStationController.Domain.Rules;

namespace Prctc.SpaceStationController.Domain.Commands
{
    public class Dock : ICommand
    {
        private readonly Station _station;
        private readonly Shuttle _shuttle;
        private readonly IRule _validationRule;

        public Dock(Station station, Shuttle shuttle, IRule validationRule)
        {
            _station = station;
            _shuttle = shuttle;
            _validationRule = validationRule;
        }
        public void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            var (iValid, failureCode) = _validationRule.Validate(_station);

            if (!iValid)
            {
                onFail(new CommandResult { IsSuccess = false, Message = failureCode });
                return;
            }
            
            _station.DockShuttle(_shuttle);
            onSuccess(new CommandResult { IsSuccess = true });
        }
    }
}