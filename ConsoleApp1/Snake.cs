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
        private List<Point> _body;
        private bool _state;
        private int _boards;
        private Direction _direction;
        public bool IsAlive => _state;
        public Point Head => _body.Last();

        public Snake(int board)
        {
            _state = true;
            _boards = board;
            _direction = Direction.Right;
            _body = new List<Point>(3);
            _body.Add(new Point(1, 1));
            _body.Add(new Point(2, 1));
            _body.Add(new Point(3, 1));
        }

        public void Kill()
        {
            _state = false;
        }

        public void Move(object? source, EventArgs e)
        {
            if (_state)
            {
                foreach (var bodyPart in _body)
                {
                    Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
                    Console.Write(" ");
                }
                _body.RemoveAt(0);
                CheckMovingDirection();
                Render();
                CheckBounds();
                CheckBodyCollision();
                ChangeSnakeDirection();
            }
        }
        public void CheckMovingDirection()
        {
            (int x, int y) lastCoor = (_body.Last().X, _body.Last().Y);
            switch (_direction)
            {
                case Direction.Up:
                    _body.Add(new Point(lastCoor.x, lastCoor.y - 1));
                    break;
                case Direction.Down:
                    _body.Add(new Point(lastCoor.x, lastCoor.y + 1));
                    break;
                case Direction.Right:
                    _body.Add(new Point(lastCoor.x + 1, lastCoor.y));
                    break;
                case Direction.Left:
                    _body.Add(new Point(lastCoor.x - 1, lastCoor.y));
                    break;
                default:
                    break;
            }
        }

        public void CheckBounds()
        {
            if (_body.Last().X == 0 || _body.Last().X == _boards ||
                _body.Last().Y == 0 || _body.Last().Y == _boards)
            {
                Kill();
            }
        }

        public void CheckBodyCollision()
        {
            var body = _body.FindAll((part) => part.X == Head.X && part.Y == Head.Y).ToList();
            if (body.Count() > 1)
                Kill();
        }

        public void ChangeSnakeDirection()
        {
            ConsoleKey key = Console.ReadKey().Key;
            //_direction = key switch
            //{
            //    ConsoleKey.UpArrow => Direction.Up,
            //    ConsoleKey.DownArrow => Direction.Down,
            //    ConsoleKey.LeftArrow => Direction.Left,
            //    ConsoleKey.RightArrow => Direction.Right,
            //    _ => _direction
            //};
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
            foreach (var point in _body)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write("*");
            }
        }
    }
}