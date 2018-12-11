using Prctc.SpaceStationController.Domain.Model;

namespace Prctc.SpaceStationController.Domain.Rules
{
    public interface IRule
    {
         (bool isValid, string failureCode) Validate(Station station);
    }
}