using System.Drawing;
using WinFormsApp2.WinFormsApp2;

namespace WinFormsApp2
{
    public class MoveTo
    {
        private readonly Canvas canvas;
        private readonly CursorManager cursorManager;

        public MoveTo(Canvas canvas, CursorManager cursorManager)
        {
            this.canvas = canvas;
            this.cursorManager = cursorManager;
        }

        public void Execute(Graphics g, Color color, int lineWidth, int xOffset, int yOffset)
        {
            
            int targetX = cursorManager.CurrentX + xOffset;
            int targetY = cursorManager.CurrentY + yOffset;

            cursorManager.MoveTo(targetX, targetY);
        }
    }
}
