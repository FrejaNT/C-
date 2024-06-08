using System.Drawing;

namespace Drawer {
    public class SnakePart
    {
        public char Symbol { get; set; }
        public Point Position { get; set; }

        public SnakePart(Point position, char symbol) {
            Position = position;
            Symbol = symbol;
        }

        public void Draw() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }

        public void Erase() {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
        }
}
}