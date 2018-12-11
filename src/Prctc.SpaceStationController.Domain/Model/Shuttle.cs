using System;
using Prctc.SpaceStationController.Core;

namespace Prctc.SpaceStationController.Domain.Model
{
    public class Shuttle : IShuttle
    {
        public Shuttle(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}