using System.Timers;

namespace ConsoleApp1
{
    class Board
    {
        private int _size;
        private System.Timers.Timer _timer;
        private Snake _snake;
        private Bonus _bonus;

        public Board(int size = 15)
        {
            _size = size;
            _snake = new Snake(size);
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnFruitEaten;
            _timer.Elapsed += _snake.Move;
            _timer.Elapsed += CheckSnake;
            _timer.Elapsed += CheckCollisions;

            BonusSpawn(this, null);
        }

        private void OnFruitEaten(object? sender, System.Timers.ElapsedEventArgs e)
        {   
            if (_bonus != null && _snake.Head.Equals(_bonus.Position))
            {
                _snake.GetBigger();
                BonusSpawn(this, null);
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

        private void CheckCollisions(object? sender, System.Timers.ElapsedEventArgs e)
        {
            CollisionObserver.collisionDetection.Invoke(_snake, _size);
        }

        public void Render()
        {
            _timer.Start();
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