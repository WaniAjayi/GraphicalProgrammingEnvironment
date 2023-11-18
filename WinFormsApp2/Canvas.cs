using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    namespace WinFormsApp2
    {
        public class Canvas
        {
            private Bitmap bitmap;
            private Graphics graphics;
            private PictureBox pictureBox1;

            public Canvas(int width, int height)
            {
                bitmap = new Bitmap(width, height);
                graphics = Graphics.FromImage(bitmap);
            }

            public void DrawLine(int startX, int startY, int endX, int endY, Color color, int lineWidth)
            {
                using (Pen pen = new Pen(color, lineWidth))
                {
                    graphics.DrawLine(pen, startX, startY, endX, endY);
                }
            }




            public void ClearCanvas()
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                    graphics.Clear(Color.White);
                pictureBox1.Refresh();
            }

            public Graphics GetCanvasBitmap()
            {
                return graphics;
            }
        }
    }
}
