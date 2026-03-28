namespace Game.UI.DescriptionSystem
{
    public class DescriptionData
    {
        public string Name { get; }
        public string Description { get; }

        public DescriptionData(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
