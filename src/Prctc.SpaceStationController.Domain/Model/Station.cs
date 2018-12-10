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
       
        internal void DockShuttle(Shuttle shuttle)
        {
            Shuttles.Add(shuttle);
        }

    }
}