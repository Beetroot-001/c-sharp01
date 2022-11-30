using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using static ConsoleApp1.Snake;

namespace ConsoleApp1
{
    internal class Board
    { 
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        private static Board? _board = null;

        private int _fieldSizeX;
        private int _fieldSizeY;
        private Point[,] _field;
        private Snake _snake;
        private Direction _snakeDirectionCurr;
        private Direction _snakeDirectionNext;
        private Fruit _fruit;

        private int _score;

        private bool _gameIsActive;

        private System.Timers.Timer _timer;

        private Board(int fieldSizeX, int fieldSizeY)
        {
            Point.MaxX = fieldSizeX;
            Point.MaxY = fieldSizeY;
            _fieldSizeX = fieldSizeX + 2;
            _fieldSizeY = fieldSizeY + 2;

            _field = new Point[_fieldSizeX, _fieldSizeY];

            for (int i = 0; i < _fieldSizeX; i++)
            {
                for (int j = 0; j < _fieldSizeY; j++)
                {
                    _field[i, j] = new Point(i, j);

                    if (i == 0 || i == _fieldSizeX - 1 || j == 0 || j == _fieldSizeY - 1)
                    {
                        _field[i, j].State = Point.PointState.BORDER;
                    }
                }
            }

            _snake = new Snake();
            _snakeDirectionCurr = Direction.RIGHT;
            _snakeDirectionNext = Direction.RIGHT;

            foreach (var item in _snake.Body)
            {
                _field[item.X, item.Y] = item;
            }

            do
            {
                _fruit = Fruit.CreateFruit(fieldSizeX, fieldSizeY);
            } while (_field[_fruit.Point.X, _fruit.Point.Y].State != Point.PointState.EMPTY);

            _field[_fruit.Point.X, _fruit.Point.Y] = _fruit.Point;

            _score = 0;
            _gameIsActive = false;


            _timer = new System.Timers.Timer();
            _timer.Interval = 400;
        }

        public static Board GetBoard()
        {
            if (_board is null)
            {
                _board = new Board(20, 20);
            }

            return _board;
        }

        public static Board GetBoard(int fieldSizeX, int fieldSizeY)
        {

            _board = new Board(fieldSizeX, fieldSizeY);
            
            return _board;
        }

        public static void StartGame()
        {
            if (_board is not null)
            {
                _board._timer.Elapsed += FrameUpdate;
                _board._timer.AutoReset = true;
                _board._gameIsActive = true;
                _board._timer.Start();

                RenderAll();

                ConsoleKey key = ConsoleKey.D;

                while (key != ConsoleKey.Escape && _board._gameIsActive)
                {
                    key = Console.ReadKey().Key;

                    Direction newDirection;

                    newDirection = key switch
                    {
                        ConsoleKey.W => Direction.UP,
                        ConsoleKey.S => Direction.DOWN,
                        ConsoleKey.A => Direction.LEFT,
                        ConsoleKey.D => Direction.RIGHT,
                        _ => _board._snakeDirectionCurr
                    };

                    if (!OppositeDirection(newDirection))
                    {
                        _board._snakeDirectionNext = newDirection;
                    }
                }
                _board._gameIsActive = false;
            }
        }

        private static void FrameUpdate(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (_board is not null)
            {
                Point renderPoint1 = new Point(),
                        renderPoint2 = new Point(),
                        renderPoint3 = new Point();

                Point nextPoint = GetNextPoint();
                if (nextPoint.State == Point.PointState.SNAKE_BODY || nextPoint.State == Point.PointState.BORDER)
                {
                    GameOverRender();
                    _board._timer.Stop();
                    _board._gameIsActive = false;
                }
                if (nextPoint.State == Point.PointState.FRUIT)
                {
                    do
                    {
                        _board._fruit = Fruit.CreateFruit(_board._fieldSizeX - 2, _board._fieldSizeY - 2);
                    } while (_board._field[_board._fruit.Point.X, _board._fruit.Point.Y].State != Point.PointState.EMPTY);

                    _board._field[_board._fruit.Point.X, _board._fruit.Point.Y] = _board._fruit.Point;
                    _board._score += 10;

                    renderPoint1 = _board._snake.Head;
                    renderPoint2 = nextPoint;
                    renderPoint3 = _board._fruit.Point;
                }
                else
                {
                    renderPoint1 = _board._snake.Tail;
                    renderPoint2 = _board._snake.Head;
                    renderPoint3 = nextPoint;
                }
                _board._snake.Move(nextPoint);
                _board._snakeDirectionCurr = _board._snakeDirectionNext;
                SmartRender(renderPoint1, renderPoint2, renderPoint3);
            }
        }
        private static bool OppositeDirection(Direction direction)
        {
            CheckBoard();

            switch (_board._snakeDirectionCurr)
            {
                case Direction.UP:
                    if (direction == Direction.DOWN)
                        return true;
                    break;
                case Direction.DOWN:
                    if (direction == Direction.UP)
                        return true;
                    break;
                case Direction.LEFT:
                    if (direction == Direction.RIGHT)
                        return true;
                    break;
                case Direction.RIGHT:
                    if (direction == Direction.LEFT)
                        return true;
                    break;
            }
            return false;
        }

        private static Point GetNextPoint()
        {
            CheckBoard();

            (int x, int y) coords = new(_board._snake.Head.X, _board._snake.Head.Y);

            switch (_board._snakeDirectionNext)
            {
                case Direction.UP:
                    coords.x--;
                    break;
                case Direction.DOWN:
                    coords.x++;
                    break;
                case Direction.LEFT:
                    coords.y--;
                    break;
                case Direction.RIGHT:
                    coords.y++;
                    break;
            }

            return _board._field[coords.x, coords.y];
        }

        public static void RenderAll()
        {
            CheckBoard();

            Console.Clear();
            Console.WriteLine($"SCORE: {_board._score}");
            for (int i = 0; i < _board._fieldSizeX; i++)
            {
                for (int j = 0; j < _board._fieldSizeY; j++)
                {
                    Console.Write(_board._field[i, j].PointRenderStr);
                }
                Console.WriteLine();
            }
        }

        private static void SmartRender(params Point[] points)
        {
            CheckBoard();

            Console.SetCursorPosition("SCORE: ".Length, 0);
            Console.Write(_board._score);

            foreach(Point item in points)
            {
                Console.SetCursorPosition(item.Y * 2, item.X + 1);
                Console.Write(item.PointRenderStr);
            }

            Console.SetCursorPosition(0, _board._fieldSizeX + 1);
        }

        private static void GameOverRender()
        {
            CheckBoard();

            Console.WriteLine( "     GAME OWER");
            Console.WriteLine($"YOUR SCORE: {_board._score}");
            Console.WriteLine("press any kew to exit...");
        }

        private static void CheckBoard()
        {
            if (_board is null)
            {
                throw new NullReferenceException("_board is null");
            }
        }
    }
}