using System;

namespace Prctc.SpaceStationController.Domain.Model
{
    public class Shuttle
    {
        internal void RequestDock(Station station)
        {
            station.DockShuttle(this);
        }
    }
}