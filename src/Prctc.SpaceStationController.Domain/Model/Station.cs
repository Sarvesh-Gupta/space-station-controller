namespace Prctc.SpaceStationController.Domain.Model
{
    using System;
    using System.Collections.Generic;

    using Prctc.SpaceStationController.Core;
    using Prctc.SpaceStationController.Domain.Rules;

    /// <summary>
    /// Station is receiver of commands.
    /// </summary>
    public class Station
    {
        private IRule _dockingRules;

        public Station()
        {
            Shuttles = new List<IShuttle>();
        }

        internal ICollection<IShuttle> Shuttles { get; }

        internal Station WithDockingRule(IRule dockingRule)
        {
            _dockingRules = dockingRule;
            return this;
        }

        internal void DockShuttle(IShuttle shuttle, Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            var (iValid, failureCode) = _dockingRules.Validate(this);
            if (!iValid)
            {
                onFail(new CommandResult { IsSuccess = false, Message = failureCode, ShuttleName = $"{shuttle.Name}(id:{shuttle.Id})" });
                return;
            }

            Shuttles.Add(shuttle);
            onSuccess(new CommandResult { IsSuccess = true, ShuttleName = $"{shuttle.Name}(id:{shuttle.Id})" });
        }

        internal void UndockShuttle(Shuttle shuttle, Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            Shuttles.Remove(shuttle);
            onSuccess(new CommandResult { IsSuccess = true, ShuttleName = $"{shuttle.Name}(id:{shuttle.Id})" });
        }
    }
}