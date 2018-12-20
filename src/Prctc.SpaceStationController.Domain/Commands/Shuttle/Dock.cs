namespace Prctc.SpaceStationController.Domain.Commands
{
    using System;

    using Prctc.SpaceStationController.Core;
    using Prctc.SpaceStationController.Domain.Model;
    using Prctc.SpaceStationController.Domain.Rules;

    public class Dock : ICommand
    {
        private readonly Station _station;
        private readonly Shuttle _shuttle;
        private readonly IRule _validationRule;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dock"/> class.
        /// </summary>
        /// <param name="station">The receiver.</param>
        /// <param name="shuttle">The param for receiver.</param>
        /// <param name="validationRule">The validation rule.</param>
        public Dock(Station station, Shuttle shuttle, IRule validationRule)
        {
            _station = station;
            _shuttle = shuttle;
            _validationRule = validationRule;
        }

        /// <summary>
        /// Executes the specified on success.
        /// </summary>
        /// <param name="onSuccess">The on success.</param>
        /// <param name="onFail">The on fail.</param>
        public void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            _station
                .WithDockingRule(_validationRule)
                .DockShuttle(_shuttle, onSuccess, onFail);
        }
    }
}