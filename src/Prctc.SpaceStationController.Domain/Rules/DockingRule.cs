using System;
using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Rules
{
    public class DockingRule : IRule
    {
        private readonly IShuttle _shuttle;

        private readonly int _maxShuttlesAllowed;

        public DockingRule(IShuttle shuttle)
        {
            _shuttle = shuttle;
            _maxShuttlesAllowed = 2;
        }

        public (bool isValid, string failureCode) Validate(Station station)
        {
            var stationShuttles = station.Shuttles;
            if (stationShuttles.Contains(_shuttle))
            {
                return (false, "SHUTTLE_ALREADY_DOCKED");
            }
            else if (stationShuttles.Count >= _maxShuttlesAllowed)
            {
                return (false, "DOCK_MAX_LIMIT_REACHED");
            }

            return (true, string.Empty);
        }
    }
}