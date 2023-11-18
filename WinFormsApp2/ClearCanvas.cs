using System.Drawing;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    public class ClearCanvas
    {
        private CursorManager cursorManager = new CursorManager();
        private readonly Canvas canvas;
        
        public ClearCanvas(Canvas canvas)
        {
            this.canvas = canvas;

        }

        public void Execute(Graphics g, Color color, int lineWidth, int parameter)
        {
            canvas.ClearCanvas();
           
            
        }
    }
}
