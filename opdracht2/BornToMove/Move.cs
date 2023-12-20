namespace BornToMove
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SweatRate { get; set; }

        public Move() { }

        public Move(int id, string name, string description, int sweatRate)
        {
            Id = id;
            Name = name;
            Description = description;
            SweatRate = sweatRate;
        }

        public override string ToString()
        {
            return $"Naam: {Name}\nBeschrijving: {Description}\nSweatRate: {SweatRate}";
        }
    }
}
