using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class DrawTo : IGraphicsCommand
    {
        private readonly PictureBox pictureBox2;
        private readonly CursorManager cursorManager;

        public DrawTo(int targetX, int targetY, PictureBox pictureBox, CursorManager cursorManager, Graphics g, Color color)
        {
            this.pictureBox2 = pictureBox;
            this.cursorManager = cursorManager;

            cursorManager.SetPosition(targetX, targetY);
            Bitmap bitmap = new(pictureBox2.Width, pictureBox2.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                g.Clear(pictureBox2.BackColor);
                g.DrawImage(pictureBox2.Image, 0, 0);

                using (Pen pen = new Pen(color, 3))
                {
                    Point startPoint = new Point(0, 0);
                    Point endPoint = new Point(targetX, targetY);
                    graphics.DrawLine(pen, startPoint, endPoint);
                }

            }
            pictureBox2.Image = bitmap;


        }


        public void Execute(Graphics g, bool fill, Color color)
        {
            int targetX = cursorManager.targetX;
            int targetY = cursorManager.targetY;

            Bitmap bitmap = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                g.Clear(pictureBox2.BackColor);
                g.DrawImage(pictureBox2.Image, 0, 0);

                using Pen pen = new Pen(color, 2);
                Point startPoint = new Point(0, 0);
                Point endPoint = new Point(targetX, targetY);
                graphics.DrawLine(pen, startPoint, endPoint);
            }

            pictureBox2.Image = bitmap;
       

            
        }

        public void Execute(int targetX, int targetY, Bitmap canvas, PictureBox pictureBox2, Graphics g, Color color)
        {
            //throw new NotImplementedException();
        }
    }
}
   

