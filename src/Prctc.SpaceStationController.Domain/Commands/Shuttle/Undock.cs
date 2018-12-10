using Prctc.SpaceStationController.Core;
using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Commands
{
    public class Undock : ICommand
    {
        public Undock(Shuttle shuttle)
        {
            
        }
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}