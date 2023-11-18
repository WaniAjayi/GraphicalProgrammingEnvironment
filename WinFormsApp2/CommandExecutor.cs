
using System.Text.RegularExpressions;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    /// <summary>
    /// Class responsible for executing drawing commands on a canvas.
    /// </summary>
    public class CommandExecutor
    {
        private readonly Canvas canvas;
        private readonly DrawTo drawTo;
        private readonly MoveTo moveTo;
        private readonly CursorManager cursorManager;
        private readonly Graphics graphics;
        private Color color;
        private readonly Rect rect;
        private readonly Triangle triangle;
        private readonly Circle circle;
        private readonly ClearCanvas clearCanvas;
        private readonly PenReset penReset;
        private bool fillEnabled; //Default fill state
        private Color FillColor; // Default fill colour

        /// <summary>
        /// Constructor initializes the necessary components for drawing on a canvas.
        /// </summary>
        /// <param name="canvasWidth">Width of the canvas.</param>
        /// <param name="canvasHeight">Height of the canvas.</param>
        /// <param name="graphics">Graphics object for drawing on a surface.</param>
        /// <param name="color">Color used for drawing.</param>
        public CommandExecutor(int canvasWidth, int canvasHeight, Graphics graphics, Color color)
        {
            this.graphics = graphics;
            this.color = color;

            // Initialize canvas and drawing components
            canvas = new Canvas(canvasWidth, canvasHeight);
            cursorManager = new CursorManager();
            drawTo = new DrawTo(canvas, cursorManager);
            moveTo = new MoveTo(canvas, cursorManager);
            rect = new Rect(canvas, cursorManager);
            triangle = new Triangle(canvas, cursorManager);
            circle = new Circle(canvas, cursorManager);
            clearCanvas = new(canvas);
            penReset = new(cursorManager);
            
        }

        /// <summary>
        /// Execute a list of drawing commands on the canvas.
        /// </summary>
        /// <param name="commands">List of drawing commands.</param>
        public void ExecuteCommands(List<string> commands)
        {
            foreach (var command in commands)
            {
                ExecuteCommand(command);
            }

            commands.Clear();
        }


        /// <summary>
        /// Execute a single drawing command on the canvas.
        /// </summary>
        /// <param name="command">Drawing command to be executed.</param>
        public void ExecuteCommand(string command)
        {
            // Check the type of command using regular expressions and execute corresponding action
            if (Regex.IsMatch(command, @"drawto\s(\d+),\s?(\d+)"))
            {
                // Extract target coordinates from the command
                Match match = Regex.Match(command, @"drawto\s(\d+),\s?(\d+)");
                int targetX = int.Parse(match.Groups[1].Value);
                int targetY = int.Parse(match.Groups[2].Value);

                // Execute the drawto command
                drawTo.DrawLineTo(targetX, targetY, graphics, color, 2);
            }
            else if (Regex.IsMatch(command, @"moveto\s(\d+),\s?(\d+)"))
            {
                // Extract offset values from the command
                Match match = Regex.Match(command, @"moveto\s(\d+),\s?(\d+)");
                int xOffsetValue = int.Parse(match.Groups[1].Value);
                int yOffsetValue = int.Parse(match.Groups[2].Value);

                // Execute the moveto command
                moveTo.Execute(graphics, color, 2, xOffsetValue, yOffsetValue);
            }
            else if (Regex.IsMatch(command, @"rect\s(\d+),\s?(\d+)"))
            {
                // Extract width and height from the command
                Match match = Regex.Match(command, @"rect\s(\d+),\s?(\d+)");
                int width = int.Parse(match.Groups[1].Value);
                int height = int.Parse(match.Groups[2].Value);

                // Execute the rect command
                rect.Execute(graphics, color, 2, width, height, fillEnabled, FillColor);
            }
            else if (Regex.IsMatch(command, @"trig\s(\d+),\s?(\d+)"))
            {
                // Extract side length from the command
                Match match = Regex.Match(command, @"trig\s(\d+),\s?(\d+)");
                int sideLength = int.Parse(match.Groups[1].Value);

                // Execute the trig command
                triangle.Execute(graphics, color, 2, sideLength, fillEnabled);
            }
            else if (Regex.IsMatch(command, @"^circle\s(\d+)"))
            {
                // Extract radius from the command
                Match match = Regex.Match(command, @"^circle\s(\d+)");
                int radius = int.Parse(match.Groups[1].Value);

                // Execute the circle command
                circle.Execute(graphics, color, 2, radius, fillEnabled);
            }
            else if (Regex.IsMatch(command, @"clear"))
            {
                // Execute the clear command
                clearCanvas.Execute(graphics, color, 2, 0);
            }
            else if (Regex.IsMatch(command, @"reset"))
            {
                // Execute the reset command
                penReset.Execute(graphics, color, 2,  5,  5);
            }
            else if (Regex.IsMatch(command, @"run"))
            {
                ExecuteCommand(command);   
            }
            else if(Regex.IsMatch(command, @"\bfill (on|off)\s(color:(red|green|blue|yellow))"))
            {
                Match match =  Regex.Match(command, @"\bfill (on|off)\s(color:(red|green|blue|yellow))");
                string fillStatus = match.Groups[1].Value;  // "on" or "off"
                string fillColor = match.Groups[2].Value;   //Extract fill colour

                //Update the fill colour based on input
                FillColor = Color.FromName(fillColor);
               fillEnabled = Regex.Match(command, @"\bfill (on|off)\s(color:(red|green|blue|yellow))\b").Groups[1].Value.ToLower() == "on";
            }
            else if (Regex.IsMatch(command, @"\bpen (red|green|blue|yellow)\b"))
            {
                Match match = Regex.Match(command, @"\bpen (red|green|blue|yellow)\b");
                string colorName = match.Groups[1].Value.ToLower();
                switch (colorName)
                {
                    case "red":
                        color = Color.Red;
                        break;
                    case "green":
                        color = Color.Green;
                        break;
                    case "blue":
                        color = Color.Blue;
                        break;
                    case "yellow":
                        color = Color.Yellow;
                        break;
                    default:
                        // Handle unsupported color
                        MessageBox.Show("Unsupported pen color: " + colorName);
                        break;
                }
                ExecuteCommand(command);
            }
        }

        /// <summary>
        /// Get the bitmap representation of the canvas.
        /// </summary>
        /// <returns>Graphics object representing the canvas.</returns>
        /// 

        /// <summary>
        /// Save the program commands to a text file.
        /// </summary>
        /// <param name="filePath">The path to the file where the program will be saved.</param>
        /// <param name="commands">The list of commands to save to the file.</param>
        /// <remarks>
        /// Each command in the list will be written to a new line in the text file.
        /// </remarks>
       


        public Graphics GetCanvasBitmap()
        {
            return canvas.GetCanvasBitmap();
        }
    }
}
