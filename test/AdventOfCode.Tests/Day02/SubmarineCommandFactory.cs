using System;

namespace AdventOfCode.Day02
{
    public static class SubmarineCommandFactory
    {
        public static SubmarineCommand CreateForRepresentation(string commandRepresentation)
        {
            var commandParts = commandRepresentation.Split(" ");

            var commandName = commandParts[0];
            var commandUnit = int.Parse(commandParts[1]);

            return commandName switch
            {
                "forward" => new ForwardCommand(commandUnit),
                "down" => new DownCommand(commandUnit),
                "up" => new UpCommand(commandUnit),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}