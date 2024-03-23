namespace Auto11.Models
{
    public class Log
    {
        public Log(Command? command, Script? script, string? response)
        {
            Command = command;
            Script = script;
            Response = response;
        }

        public Command? Command { get; set; }
        public Script? Script { get; set; }
        public Device? Device { get; set; }
        public string? Response { get; set; }
    }
}
