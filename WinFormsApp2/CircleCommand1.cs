using System.Drawing;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    public class Circle
    {
        private readonly Canvas canvas;
        private readonly CursorManager cursorManager;
        private Color Color = Color.Transparent;    //Default fill colour

        public Circle(Canvas canvas, CursorManager cursorManager)
        {
            this.canvas = canvas;
            this.cursorManager = cursorManager;
        }

        public void SetFillColor(Color color)
        { 
            this.Color = color;
        }

        public void Execute(Graphics g, Color color, int lineWidth, int radius, bool fillEnabled)
        {
            int centerX = cursorManager.CurrentX;
            int centerY = cursorManager.CurrentY;

            int diameter = radius * 2;
            int x = centerX - radius;
            int y = centerY - radius;

            if (fillEnabled)
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, x, y, diameter, diameter);
                }
            }
            else
            {

                using (Pen pen = new Pen(color, lineWidth))
                {
                    g.DrawEllipse(pen, x, y, diameter, diameter);
                }
            }
        }
    }
}
