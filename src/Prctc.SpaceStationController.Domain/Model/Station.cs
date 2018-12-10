using System;
using System.Collections.Generic;

namespace Prctc.SpaceStationController.Domain.Model
{
    public class Station
    {
        public Station(int maxShuttlesAllowed)
        {
            Shuttles = new List<Shuttle>();
            MaxShuttlesAllowed = maxShuttlesAllowed;
        }
        public ICollection<Shuttle> Shuttles { get; }

        public int MaxShuttlesAllowed { get; }
        internal bool CanShuttleDock(Shuttle shuttle)
        {
            if (!Shuttles.Contains(shuttle)
                && Shuttles.Count < MaxShuttlesAllowed)
            {
                return true;
            }

            return false;
        }

        internal void DockShuttle(Shuttle shuttle)
        {
            Shuttles.Add(shuttle);
        }

    }
}