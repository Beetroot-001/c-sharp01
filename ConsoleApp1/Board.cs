namespace ConsoleApp1
{
    class Board
    {
        private int _size;
        private System.Timers.Timer _timer;
        private System.Timers.Timer _spawnTimer;
        private Snake _snake;
        private Bonus _bonus;

        public Board(int size = 15)
        {
            _size = size;
            _snake = new Snake(size);
            _timer = new System.Timers.Timer(1000);
            _spawnTimer = new System.Timers.Timer(_size * 1100);
            _timer.Elapsed += CheckEat;
            _timer.Elapsed += _snake.Move;
            _timer.Elapsed += CheckSnake;
            _spawnTimer.Elapsed += BonusSpawn;
        }

        private void CheckEat(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (_bonus != null && _snake.Head.Equals(_bonus.Position))
            {
                _snake.GetBigger();
            }
        }

        private void BonusSpawn(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _bonus = new Bonus(_size);
        }

        private void CheckSnake(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_snake.IsAlive)
            {
                _timer.Stop();
                Console.Clear();
                Console.WriteLine("Game over!");
            }
        }

        public void Render()
        {
            _timer.Start();
            _spawnTimer.Start();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < _size; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");

                Console.SetCursorPosition(i, 0);
                Console.Write("#");

                Console.SetCursorPosition(i, _size - 1);
                Console.Write("#");

                Console.SetCursorPosition(_size - 1, i);
                Console.Write("#");
            }
        }

    }
}