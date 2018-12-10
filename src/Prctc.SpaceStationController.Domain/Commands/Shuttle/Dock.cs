
using System;
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
            bool canDock = CanShuttleDock();
            if (canDock)
            {
               DockToStation();
            }
        }

        private bool CanShuttleDock()
        {
            var stationShuttles = _station.Shuttles;
            if (!stationShuttles.Contains(_shuttle)
                && stationShuttles.Count < _station.MaxShuttlesAllowed)
            {
                return true;
            }

            return false;
        }

        private void DockToStation()
        {
             _station.DockShuttle(_shuttle);   
        }
    }
}