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
            _board = new Board();
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

    class Snake
    {
        private List<Point> _body;
        private bool _state;
        private Direction _direction;
        //private int _snakeLenght => _body.Count();
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

        public void Kill()
        {
            _state = false;
        }

        public async void Move(object? source, EventArgs e)
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
                CheckBoundsA();
                ChangeSnakeDirection();
                await Task.Yield();
            }
        }
        public async void CheckBoundsA()
        {
            if (CheckBounds())
            {
                Kill();
            }
            await Task.Yield();
        }
        public bool CheckBounds()
        {
            return _body.Last().X == 0 || _body.Last().X == 14 ||
                _body.Last().Y == 0 || _body.Last().Y == 14;
        }
        public async void ChangeSnakeDirection()
        {
            ConsoleKey key = Console.ReadKey().Key;
            _direction = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => _direction
            };
            await Task.Yield();
        }

        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var point in _body)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write("*");
            }
            //await Task.Yield();
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

    class Bonus
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

    class Board
    {
        private int _size;
        private System.Timers.Timer _timer;
        private Snake _snake;
        private Bonus _bonus;

        //public Action<ConsoleKey> ChangeDirection;
        public Action<ConsoleKey> ChangeDirection;

        public Board(int size = 15)
        {
            _size = size;
            _snake = new Snake();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _snake.Move;
            //_timer.Elapsed += CheckBoundsA;
        }

        public async void Render()
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