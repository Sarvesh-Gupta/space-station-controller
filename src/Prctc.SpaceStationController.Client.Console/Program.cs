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
            var shuttle = new Shuttle(1, "Columbia");
            IRule dockingRule = new DockingRule(shuttle);
            ICommand dock = new Dock(station, shuttle, dockingRule);
            var controller = new StationController();
            controller.ExecuteCommand(dock, DockingSuccessful, DockingFailed);

            var shuttle2 = new Shuttle(2, "Discovery");
            dockingRule = new DockingRule(shuttle2);
            dock = new Dock(station, shuttle2, dockingRule);
            controller.ExecuteCommand(dock, DockingSuccessful, DockingFailed);

            var shuttle3 = new Shuttle(3, "Challenger");
            dockingRule = new DockingRule(shuttle3);
            dock = new Dock(station, shuttle3, dockingRule);
            controller.ExecuteCommand(dock, DockingSuccessful, DockingFailed);

            var undock = new Undock(station, shuttle2);
            controller.ExecuteCommand(undock, Undocked, (result) => { });

            controller.ExecuteCommand(dock, DockingSuccessful, DockingFailed);
        }

        static void DockingSuccessful(Core.CommandResult result)
        {
            System.Console.WriteLine($"Success!!, {result.ShuttleName} got docked.");
        }

        static void DockingFailed(Core.CommandResult result)
        {
            System.Console.WriteLine($"Failure!!, {result.ShuttleName} could not be docked. Reason>>> {result.Message}");
        }

        static void Undocked(Core.CommandResult result)
        {
            System.Console.WriteLine($"{result.ShuttleName} Undocked.");
        }
    }
}
