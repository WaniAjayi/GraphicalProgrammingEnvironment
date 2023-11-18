using System.Drawing;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    public class Triangle
    {
        private readonly Canvas canvas;
        private readonly CursorManager cursorManager;
        private Color fillColor = Color.Transparent;    //Default fill colour

        public Triangle(Canvas canvas, CursorManager cursorManager)
        {
            this.canvas = canvas;
            this.cursorManager = cursorManager;
        }

        public void SetFillColor(Color fillColor)
        { 
            this.fillColor = fillColor;
        }


        public void Execute(Graphics g, Color fillcolor, int lineWidth, int sideLength, bool fillEnabled)
        {
            int startX = cursorManager.CurrentX;
            int startY = cursorManager.CurrentY;

            Point[] points = new Point[]
            {
                new Point(startX, startY),
                new Point(startX + sideLength, startY),
                new Point(startX - sideLength / 2, startY + sideLength)
            };

            if (fillEnabled)
            {
                using (SolidBrush brush = new SolidBrush(fillcolor))
                {
                    g.FillPolygon(brush, points);
                }
            }
            else
            {

                using (Pen pen = new Pen(fillcolor, lineWidth))
                {
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
