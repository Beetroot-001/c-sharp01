using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
    internal class Snake
    {
        public Snake(int sizeX, int sizeY, char Symbol, ConsoleColor snakeColor = ConsoleColor.Yellow)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _snakeColor = snakeColor;
            _symbol = Symbol;

            SnakeBody = new List<Dot>();

            Dot[] dots = new Dot[]
            {
                new Dot(_sizeX/2-1, _sizeY / 2,_symbol),
                new Dot(_sizeX/2, _sizeY / 2,_symbol),
                new Dot(_sizeX/2+1, _sizeY / 2,_symbol),
            };

            SnakeBody.AddRange(dots);
        }

        private readonly int _sizeX;
        private readonly int _sizeY;
        private readonly char _symbol;
        private readonly ConsoleColor _snakeColor;

        public static int CountOfEatten { get; private set; }

        private Direction _direction = Direction.Right;

        public List<Dot> SnakeBody { get; set; }

        /// <summary>
        /// Displays the snake on the screen
        /// </summary>
        public void DisplaySnake()
        {
            foreach (var item in SnakeBody.ToList())
            {
                item.PrintDot(_snakeColor);
            }
        }

        /// <summary>
        /// Adds next move of the snake
        /// </summary>
        public void GetNextMove()
        {
            switch (_direction)
            {
                case Direction.Right:
                    {
                        SnakeBody.Add(new Dot(SnakeBody[SnakeBody.Count - 1].X + 1, SnakeBody[SnakeBody.Count - 1].Y, this._symbol));
                        SnakeBody[0].DelDote();
                        SnakeBody.RemoveAt(0);
                        DisplaySnake();
                        break;
                    }
                case Direction.Left:
                    {
                        SnakeBody.Add(new Dot(SnakeBody[SnakeBody.Count - 1].X - 1, SnakeBody[SnakeBody.Count - 1].Y, this._symbol));
                        SnakeBody[0].DelDote();
                        SnakeBody.RemoveAt(0);
                        DisplaySnake();
                        break;
                    }
                case Direction.Up:
                    {
                        SnakeBody.Add(new Dot(SnakeBody[SnakeBody.Count - 1].X, SnakeBody[SnakeBody.Count - 1].Y - 1, this._symbol));
                        SnakeBody[0].DelDote();
                        SnakeBody.RemoveAt(0);
                        DisplaySnake();
                        break;
                    }
                case Direction.Down:
                    {
                        SnakeBody.Add(new Dot(SnakeBody[SnakeBody.Count - 1].X, SnakeBody[SnakeBody.Count - 1].Y + 1, this._symbol));
                        SnakeBody[0].DelDote();
                        SnakeBody.RemoveAt(0);
                        DisplaySnake();
                        break;
                    }
            }
        }

        /// <summary>
        /// Enlarges the snake
        /// </summary>
        private void SnakeGrow() => SnakeBody.Add(new Dot(SnakeBody[SnakeBody.Count - 1].X, SnakeBody[SnakeBody.Count - 1].Y, this._symbol));

        /// <summary>
        /// Compares if the snake has eaten the fruit. If yes, a new fruit is added on the board
        /// </summary>
        /// <param name="fruit"></param>
        public void Eat(Fruit fruit)
        {
            if (IsEatingFruit(fruit))
            {
                Snake.CountOfEatten++;
                SnakeGrow();
                EatingFruit(); 
                if (Program.speed>=50)
                    Program.speed -= 20;

            }

            while (fruit.IsSpawnInSnake(this))
            {
                fruit.NewFruit();
            }
        }

        /// <summary>
        /// Enables the user to change the snake's direction of the movement
        /// </summary>
        /// <param name="keyInfo"></param>
        public void MoveOfSnake(ConsoleKeyInfo keyInfo)
        {
            if (_direction == Direction.Up || _direction == Direction.Down)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            _direction = Direction.Left;
                            return;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            _direction = Direction.Right;
                            return;
                        }
                }
            }
            else if (_direction == Direction.Right || _direction == Direction.Left)
                switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        _direction = Direction.Up;
                        return;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        _direction = Direction.Down;
                        return;
                    }
            }
        }

        /// <summary>
        /// Checks if the snake hit the wall. yes - true; no - false
        /// </summary>
        /// <returns></returns>
        public bool IsHittingWall()
        {
            return SnakeBody[SnakeBody.Count - 1].X == _sizeX || SnakeBody[SnakeBody.Count - 1].X == 0 || SnakeBody[SnakeBody.Count - 1].Y == _sizeY || SnakeBody[SnakeBody.Count - 1].Y == 0;
        }

        /// <summary>
        /// Checks if the snake hit its body. yes - true; no - false
        /// </summary>
        /// <returns></returns>
        public bool IsHittingBody()
        {
            for (int i = 0; i < SnakeBody.Count - 1; i++)// -1 щоб не порівнювати голову змії з головою
            {
                if (SnakeBody[i].Equals(SnakeBody[SnakeBody.Count - 1]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the snake has eaten the fruit
        /// </summary>
        /// <param name="fruit"></param>
        /// <returns></returns>
        public bool IsEatingFruit(Fruit fruit)
        {
            return SnakeBody[SnakeBody.Count - 1].Equals(fruit.Dot);
        }

        public delegate void Eating();

        public event  Eating EatingFruit;



    }
}
