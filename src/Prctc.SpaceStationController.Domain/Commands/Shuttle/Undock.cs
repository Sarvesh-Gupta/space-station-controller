namespace Prctc.SpaceStationController.Domain.Commands
{
    using System;

    using Prctc.SpaceStationController.Core;
    using Prctc.SpaceStationController.Domain.Model;

    public class Undock : ICommand
    {
        private readonly Station _station;
        private readonly Shuttle _shuttle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Undock"/> class.
        /// </summary>
        /// <param name="station">The receiver.</param>
        /// <param name="shuttle">The param for receiver.</param>
        public Undock(Station station, Shuttle shuttle)
        {
            _station = station;
            _shuttle = shuttle;
        }

        /// <summary>
        /// Executes the specified on success.
        /// </summary>
        /// <param name="onSuccess">The on success.</param>
        /// <param name="onFail">The on fail.</param>
        public void Execute(Action<CommandResult> onSuccess, Action<CommandResult> onFail)
        {
            _station.UndockShuttle(_shuttle, onSuccess, onFail);
        }
    }
}