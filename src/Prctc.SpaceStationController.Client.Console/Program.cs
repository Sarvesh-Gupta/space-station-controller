using System;
using Prctc.SpaceStationController.Domain.Model;
using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Commands;
using Prctc.SpaceStationController.Domain.Rules;

namespace Prctc.SpaceStationController.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var station = new Station();
            var shuttle = new Shuttle();
            IRule dockingRule = new DockingRule(shuttle);
            ICommand dock = new Dock(station, shuttle, dockingRule);
            var controller = new StationController();
            controller.ExecuteCommand(dock, shuttle.DockingSuccessful, shuttle.DockingFailed);

            shuttle = new Shuttle();
            dockingRule = new DockingRule(shuttle);
            dock = new Dock(station, shuttle, dockingRule);
            controller.ExecuteCommand(dock, shuttle.DockingSuccessful, shuttle.DockingFailed);

            shuttle = new Shuttle();
            dockingRule = new DockingRule(shuttle);
            dock = new Dock(station, shuttle, dockingRule);
            controller.ExecuteCommand(dock, shuttle.DockingSuccessful, shuttle.DockingFailed);
        }
    }
}
