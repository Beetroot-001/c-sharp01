using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Point
    {
        public static readonly string[] PointStrs = { "  ", "██", "@@", "▒▒", "{}" };
        public static int MaxX = 20;
        public static int MaxY = 20;

        public enum PointState
        {
            EMPTY = 0,
            BORDER = 1,
            SNAKE_HEAD = 2,
            SNAKE_BODY = 3,
            FRUIT = 4
        }

        private (int x, int y) _coords;
        private PointState _state;
        private string _pointRenderStr;

        public int X
        {
            get => _coords.x;
            set => _coords.x = value >= 0 && value < MaxX+2 ? value : throw new ArgumentOutOfRangeException("Point.X out of range");
        }
        public int Y
        {
            get => _coords.y;
            set => _coords.y = value >= 0 && value < MaxY+2 ? value : throw new ArgumentOutOfRangeException("Point.Y out of range");
        }
        public PointState State
        {
            get => _state;
            set
            {
                _state = value;
                _pointRenderStr = PointStrs[(int)_state];
            }
        }
        public string PointRenderStr => _pointRenderStr;

        public Point()
        { 
            _state = PointState.EMPTY;
            _pointRenderStr = PointStrs[(int)_state];
        }

        public Point(int x, int y, PointState state = PointState.EMPTY)
        {
            X = x;
            Y = y;
            _state = state;
            _pointRenderStr = PointStrs[(int)_state];
        }
    }
}
