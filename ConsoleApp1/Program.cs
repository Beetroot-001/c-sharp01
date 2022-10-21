using System.ComponentModel;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameManager manager = GameManager.GetGame();
            manager.Start();
            manager.Update();
            Thread.Sleep(Timeout.Infinite);


        }
    }

    interface IRender
    {
        void Render();
    }


    class GameManager
    {
        private static GameManager _instance;

        private Board _board;

        public static GameManager GetGame()
        {
            _instance ??= new GameManager();
            return _instance;
        }

        private GameManager()
        {
            _board = new Board(30);
        }

        public void Start()
        {
            GetGame();
        }

        public void Update()
        {
            _board.Render();
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    class Snake : IRender
    {
        private List<Point> _body;
        private bool _state;
        private Direction _direction;
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
                
                Render();
            }

        }
        public void ChangeSnakeDirection(ConsoleKey key)
        {
            _direction = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => _direction
            };
        }

        private int _snakeLenght => _body.Count();
        public bool IsAlive => _state;

        public List<Point> Body => _body;

        public Snake()
        {
            _state = true;
            _direction = Direction.Right;
            _body = new List<Point>(3);
            _body.Add(new Point(1, 1));
            _body.Add(new Point(2, 1));
            _body.Add(new Point(3, 1));
        }

        public bool CheckBounds(int boardSize)
        {
            return _body.First().X == 0 || _body.First().X == boardSize ||
                _body.First().Y == 0 || _body.First().Y == boardSize;
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

    class Point
    {
        private int _x;
        private int _y;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }

    class Bonus : IRender
    {
        Point position;

        public Bonus(int x, int y)
        {
            position = new Point(x, y);
        }

        public void Render()
        {
            throw new NotImplementedException();
        }
    }

    class Board : IRender
    {
        private int _size;
        private System.Timers.Timer _timer;
        private Snake _snake;
        private Bonus _bonus;

        public Action<ConsoleKey> ChangeDirection;

        public Board(int size = 15)
        {
            _size = size;
            _snake = new Snake();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _snake.Move;
            ChangeDirection += _snake.ChangeSnakeDirection;
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
            _snake.Render();

        }
    }
}