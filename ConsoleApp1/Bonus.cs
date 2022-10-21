namespace ConsoleApp1
{
    class Bonus
    {
        private char _symbol = '@';
        public Point Position;

        public Bonus(int size)
        {
            var rand = new Random();
            int x = rand.Next(1, size - 1);
            int y = rand.Next(1, size - 1);
            Position = new Point(x, y);
            Render();
        }

        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_symbol);
        }
    }
}