using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Snake
    {
        private List<Point> _body;

        public List<Point> Body
        {
            get => _body;
        }

        public Point Head => _body.First();

        public Point Tail => _body.Last();

        public Snake()
        {
            _body = new List<Point>();

            for (int i = 4; i > 1 ; i--)
            {
                _body.Add(new Point(2, i, Point.PointState.SNAKE_BODY));
            }

            Head.State = Point.PointState.SNAKE_HEAD;
        }

        public void Move(Point nextPoint)
        {
            Head.State = Point.PointState.SNAKE_BODY;
            _body = _body.Prepend(nextPoint).ToList();

            if (nextPoint.State != Point.PointState.FRUIT)
            {
                Tail.State = Point.PointState.EMPTY;
                _body.Remove(Tail);
            }

            Head.State = Point.PointState.SNAKE_HEAD;
        }
    }
}