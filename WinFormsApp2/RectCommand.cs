using System.Drawing;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    /// <summary>
    /// Represents a rectangular drawing operation on a Graphics object.
    /// </summary>
    public class Rect
    {
        //private readonly Canvas canvas;
        private readonly CursorManager cursorManager;

        /// <summary>
        /// Initializes a new instance of the Rect class with the specified Canvas and CursorManager objects.
        /// </summary>
        /// <param name="canvas">The Canvas object used to draw the rectangle.</param>
        /// <param name="cursorManager">The CursorManager object used to get the current cursor position.</param>
        public Rect(Canvas canvas, CursorManager cursorManager)
        {
            this.cursorManager = cursorManager;
        }

        public Color Fillcolor { get; private set; }
        
        /// <summary>
        /// Executes the rectangular drawing operation using the specified Graphics object, color, line width, width, and height.
        /// </summary>
        /// <param name="g">The Graphics object used to draw the rectangle.</param>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="lineWidth">The width of the rectangle's lines.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void Execute(Graphics g, Color color, int lineWidth, int width, int height, bool fillEnabled, Color FillColor)
        {
            int startX = cursorManager.CurrentX;
            int startY = cursorManager.CurrentY;

            if (fillEnabled)
            {
                using (SolidBrush brush = new SolidBrush(Fillcolor))
                {
                    g.FillRectangle(brush, startX, startY, width, height);
                }
            }
            else
            {

                using (Pen pen = new Pen(color, lineWidth))
                {
                    g.DrawRectangle(pen, startX, startY, width, height);
                }
            }
        }
    }
}