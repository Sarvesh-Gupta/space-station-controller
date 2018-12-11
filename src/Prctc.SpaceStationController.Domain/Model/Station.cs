using System;
using System.Collections.Generic;

namespace Prctc.SpaceStationController.Domain.Model
{
    public class Station
    {
        public Station()
        {
            Shuttles = new List<IShuttle>();
        }
        internal ICollection<IShuttle> Shuttles { get; }

        internal void DockShuttle(IShuttle shuttle)
        {
            Shuttles.Add(shuttle);
        }

        internal void UndockShuttle(Shuttle shuttle)
        {
            Shuttles.Remove(shuttle);
        }
    }
}