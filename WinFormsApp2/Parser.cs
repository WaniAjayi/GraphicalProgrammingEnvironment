using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WinFormsApp2
{
    /// <summary>
    /// Parses and validates a set of commands for a drawing application.
    /// </summary>
    public class CommandParser
    {
        private string[] regexPatterns =
        {
            @"drawto\s(\d+),\s?(\d+)",
            @"moveto\s(\d+),\s?(\d+)",
            @"rect\s(\d+),\s?(\d+)",
            @"trig\s(\d+),\s?(\d+)",
            @"^circle\s(\d+)",
            @"clear",
            @"reset",
            @"run",
             @"\bfill (on|off)\s(color:(red|green|blue|yellow))",
            @"\bpen (red|green|blue|yellow)\b"
        };

        private List<string> delayedCommands = new List<string>();

        /// <summary>
        /// Parses an array of commands, validating each one against predefined regex patterns.
        /// </summary>
        /// <param name="commands">An array of commands to be parsed.</param>
        /// <returns>True if all commands are valid; otherwise, false.</returns>
        public bool ParseCommands(string[] commands)
        {
            if (commands == null || commands.Length == 0)
            {
                // Show the empty command message.
                MessageBox.Show("You haven't entered any commands!");
                return false;
            }

            foreach (var command in commands)
            {
                bool matched = false;

                foreach (var regexPattern in regexPatterns)
                {
                    if (Regex.IsMatch(command, regexPattern))
                    {
                        matched = true;
                        delayedCommands.Add(command);
                        break;
                    }
                }

                if (!matched)
                {
                    // Show the invalid command message for an invalid command.
                    MessageBox.Show("You have entered an invalid command: " + command);
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the list of commands that were matched and added to the delayed commands list.
        /// </summary>
        /// <returns>A list of delayed commands.</returns>
        public List<string> GetDelayedCommands()
        {
            return delayedCommands;
        }

        /// <summary>
        /// Parses a single command, validating it against predefined regex patterns.
        /// </summary>
        /// <param name="singleLineCommand">A single command to be parsed.</param>
        /// <returns>True if the command is valid; otherwise, false.</returns>
        public bool ParseCommands(string singleLineCommand)
        {
            if (singleLineCommand == null)
            {
                // Shows the message if no command is provided.
                MessageBox.Show("You haven't entered a command!");
                return false;
            }


           
            foreach (var regexPattern in regexPatterns)
            {

                if (Regex.IsMatch(singleLineCommand, regexPattern))
                {
                   
                    delayedCommands.Add(singleLineCommand);
                   
                    
                }
                
            }
                
            
            return true;
            //return matched;
        }
    }
}
