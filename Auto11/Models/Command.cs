namespace Auto11.Models
{
    public class Command
    {
        public Command(string? instruction, string? description, int? delay)
        {
            Instruction = instruction;
            Description = description;
            Delay = delay;
        }

        public string? Instruction { get; set; }
        public string? Description { get; set; }
        public int? Delay { get; set; }
    }
}
