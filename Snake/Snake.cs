using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        private ConsoleColor _headColor;

        private ConsoleColor _bodyColor;

        public Snake(int initialX, int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLength = 3)
        {
            _headColor = headColor;
            _bodyColor = bodyColor;
            Head = new Pixel(initialX, initialY, headColor);
            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColor));
            }
            Draw();
        }

        public Pixel Head { get; private set; }

        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Move(Direct direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));
            if (!eat)
                Body.Dequeue();
            Head = direction switch
            {
                Direct.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
                Direct.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
                Direct.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
                Direct.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
                _ => Head
            };
            Draw();
        }
        public void Draw()
        {
            Head.Draw();
            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();
            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
