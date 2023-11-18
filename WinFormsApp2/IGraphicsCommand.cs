using System.Drawing;

namespace WinFormsApp2
{
    public interface IGraphicsCommand
    {
        void Execute(Graphics g, Color color, int lineWidth);
        void Execute(int targetX, int targetY, Graphics g, bool fill, Color color);
    }
}