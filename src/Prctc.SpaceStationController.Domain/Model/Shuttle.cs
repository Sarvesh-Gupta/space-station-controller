using System;
using Prctc.SpaceStationController.Core;

namespace Prctc.SpaceStationController.Domain.Model
{
    public class Shuttle : IShuttle
    {
        public void DockingSuccessful(CommandResult result)
        {
            Console.WriteLine($"Success!!, I got docked.");
        }

         public void DockingFailed(CommandResult result)
        {
            Console.WriteLine($"Failure!!, I could not be docked. Reason>>> {result.Message}");
        }
    }
}