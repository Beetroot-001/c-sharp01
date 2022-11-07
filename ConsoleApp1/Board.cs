using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private int _fieldSizeX;
        private int _fieldSizeY;
        private Point[,] _field;
        private Snake _snake;
        private Direction _snakeDirection;
        private Fruit _fruit;

        private int _score;

        private bool _gameIsActive;

        public Board(int fieldSizeX, int fieldSizeY)
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
            _snakeDirection = Direction.RIGHT;

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
        }

        public void StartGame()
        {
            _gameIsActive = true;
            RenderAll();
            Task? frameUpdateTasck = FrameUpdate();

            ConsoleKey key = ConsoleKey.D;

            while (key != ConsoleKey.Escape && _gameIsActive)
            {
                key = Console.ReadKey().Key;

                Direction newDirection;

                newDirection = key switch
                {
                    ConsoleKey.W => Direction.UP,
                    ConsoleKey.S => Direction.DOWN,
                    ConsoleKey.A => Direction.LEFT,
                    ConsoleKey.D => Direction.RIGHT,
                    _ => _snakeDirection
                };

                if (!OppositeDirection(newDirection))
                {
                    _snakeDirection = newDirection;
                }
            }
            _gameIsActive = false;
        }

        private async Task FrameUpdate()
        {
            while (_gameIsActive)
            {
                Point renderPoint1 = new Point(), 
                      renderPoint2 = new Point(), 
                      renderPoint3 = new Point();

                Point nextPoint = GetNextPoint();
                if (nextPoint.State == Point.PointState.SNAKE_BODY || nextPoint.State == Point.PointState.BORDER)
                {
                    _gameIsActive = false;
                    GameOverRender();
                    break;
                }
                if (nextPoint.State == Point.PointState.FRUIT)
                {
                    do
                    {
                        _fruit = Fruit.CreateFruit(_fieldSizeX - 2, _fieldSizeY - 2);
                    } while (_field[_fruit.Point.X, _fruit.Point.Y].State != Point.PointState.EMPTY);

                    _field[_fruit.Point.X, _fruit.Point.Y] = _fruit.Point;
                    _score += 10;

                    renderPoint1 = _snake.Head;
                    renderPoint2 = nextPoint;
                    renderPoint3 = _fruit.Point;
                } else
                {
                    renderPoint1 = _snake.Tail;
                    renderPoint2 = _snake.Head;
                    renderPoint3 = nextPoint;
                }
                _snake.Move(nextPoint);
                SmartRender(renderPoint1, renderPoint2, renderPoint3);
                await Task.Delay(1000);
            }
        }

        private bool OppositeDirection(Direction direction)
        {
            switch (_snakeDirection)
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

        private Point GetNextPoint()
        {
            (int x, int y) coords = new(_snake.Head.X, _snake.Head.Y);

            switch (_snakeDirection)
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

            return _field[coords.x, coords.y];
        }

        public void RenderAll()
        {
            Console.Clear();
            Console.WriteLine($"SCORE: {_score}");
            for (int i = 0; i < _fieldSizeX; i++)
            {
                for (int j = 0; j < _fieldSizeY; j++)
                {
                    Console.Write(_field[i, j].PointRenderStr);
                }
                Console.WriteLine();
            }
        }

        private void SmartRender(params Point[] points)
        {
            Console.SetCursorPosition("SCORE: ".Length, 0);
            Console.Write(_score);

            foreach(Point item in points)
            {
                Console.SetCursorPosition(item.Y * 2, item.X + 1);
                Console.Write(item.PointRenderStr);
            }

            Console.SetCursorPosition(0, _fieldSizeX + 1);
        }

        private void GameOverRender()
        {
            Console.WriteLine( "     GAME OWER");
            Console.WriteLine($"YOUR SCORE: {_score}");
            Console.WriteLine("press any kew to exit...");
        }
    }
}