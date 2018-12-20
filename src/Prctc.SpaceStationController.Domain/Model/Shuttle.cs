namespace Prctc.SpaceStationController.Domain.Model
{
    public class Shuttle : IShuttle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shuttle"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public Shuttle(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}