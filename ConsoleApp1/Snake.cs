namespace ConsoleApp1
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    class Snake
    {
        public List<Point> Body;
        private bool _state;
        private int _boards;
        private Direction _direction;
        public bool IsAlive => _state;
        public Point HeadImg => Body.Last();
        public Point Head => Body.Last();

        public Snake(int board)
        {
            _state = true;
            _boards = board;
            _direction = Direction.Right;
            Body = new List<Point>(3);
            Body.Add(new Point(1, 1));
            Body.Add(new Point(2, 1));
            Body.Add(new Point(3, 1));
            Render();
        }

        public void Kill()
        {
            _state = false;
        }

        public void Move(object? source, EventArgs e)
        {
            if (_state)
            {
                foreach (var bodyPart in Body)
                {
                    Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
                    Console.Write(" ");
                }
                Body.RemoveAt(0);
                CheckMovingDirection();
                Render();
                ChangeSnakeDirection();
            }
        }
        public void CheckMovingDirection()
        {
            (int x, int y) lastCoor = (Body.Last().X, Body.Last().Y);
            switch (_direction)
            {
                case Direction.Up:
                    Body.Add(new Point(lastCoor.x, lastCoor.y - 1));
                    break;
                case Direction.Down:
                    Body.Add(new Point(lastCoor.x, lastCoor.y + 1));
                    break;
                case Direction.Right:
                    Body.Add(new Point(lastCoor.x + 1, lastCoor.y));
                    break;
                case Direction.Left:
                    Body.Add(new Point(lastCoor.x - 1, lastCoor.y));
                    break;
                default:
                    break;
            }
        }

        public void ChangeSnakeDirection()
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow && _direction != Direction.Down)
            {
                _direction = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow && _direction != Direction.Up)
            {
                _direction = Direction.Down;
            }
            else if (key == ConsoleKey.LeftArrow && _direction != Direction.Right)
            {
                _direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow && _direction != Direction.Left)
            {
                _direction = Direction.Right;
            }
        }

        public void GetBigger()
        {
            CheckMovingDirection();
            Render();
        }

        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var point in Body)
            {
                try
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write("*");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Kill();
                }
            }
        }
    }
}