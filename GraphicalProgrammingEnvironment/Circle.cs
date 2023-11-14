using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingEnvironment
{
  
        public class CircleCommand : IGraphicsCommand
        {
            //private readonly int targetX;
            //readonly CursorManager stateManager;
            private int radius;
            readonly CursorManager cursorManager;

                 // public CircleCommand(int x, DrawingSettings cordinatesStateManager)
                 //    {
                 //         targetX = x; //radius
                 //         this.stateManager = cordinatesStateManager;
                //     }

            

            public void Execute(Graphics g, bool fill, Color color)
            {
                color = Color.Red;
                Pen pen = new(color, 1);
                int diameter = radius * 2;

                int x = cursorManager.targetX - radius;
                int y = cursorManager.targetY - radius;

                if (fill)
                {
                    g.FillEllipse(new SolidBrush(color), x, y, diameter, diameter);
                }
                else
                {
                    g.DrawEllipse(pen, x, y, diameter, diameter);
                }
            }

        public void Execute(int targetX, int targetY, Bitmap canvas, PictureBox pictureBox2, Graphics g, Color color)
        {
            throw new NotImplementedException();
        }

        public CircleCommand(int radius, CursorManager cursorManager)
            {
                this.radius = radius;
                this.cursorManager = cursorManager;
            }

        }
}
