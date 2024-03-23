namespace Auto11.Models
{
    public class Script
    {
        public Script(string? name, string? version, string? model, List<Command>? commands)
        {
            Name = name;
            Version = version;
            Model = model;
            Commands = commands;
        }

        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? Model { get; set; }
        public List<Command>? Commands { get; set; }
    }
}
