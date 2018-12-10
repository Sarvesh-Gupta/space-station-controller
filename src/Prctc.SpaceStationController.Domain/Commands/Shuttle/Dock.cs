
using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Commands
{
    public class Dock : ICommand
    {
        private readonly Station _station;
        private readonly Shuttle _shuttle;

        public Dock(Station station, Shuttle shuttle)
        {
            _station = station;
            _shuttle = shuttle;
        }
        public void Execute()
        {
            bool canDock = _station.CanShuttleDock(_shuttle);
            if (canDock)
            {
                _shuttle.RequestDock(_station);
            }
        }
    }
}