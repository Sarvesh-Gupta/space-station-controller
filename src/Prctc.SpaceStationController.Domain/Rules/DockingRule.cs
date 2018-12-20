namespace Prctc.SpaceStationController.Domain.Rules
{
    using Prctc.SpaceStationController.Domain.Model;

    public class DockingRule : IRule
    {
        private readonly IShuttle _shuttle;

        private readonly int _maxShuttlesAllowed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DockingRule"/> class.
        /// </summary>
        /// <param name="shuttle">The shuttle.</param>
        public DockingRule(IShuttle shuttle)
        {
            _shuttle = shuttle;
            _maxShuttlesAllowed = 2;
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="station">
        /// The station.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>(bool isValid, string failureCode)</cref>
        ///     </see>
        ///     .
        /// </returns>
        public (bool isValid, string failureCode) Validate(Station station)
        {
            var stationShuttles = station.Shuttles;
            if (stationShuttles.Contains(_shuttle))
            {
                return (false, "SHUTTLE_ALREADY_DOCKED");
            }

            if (stationShuttles.Count >= _maxShuttlesAllowed)
            {
                return (false, "ALL_DOCKS_OCCUPIED");
            }

            return (true, string.Empty);
        }
    }
}