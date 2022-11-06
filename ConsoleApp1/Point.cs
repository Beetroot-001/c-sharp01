namespace ConsoleApp1
{
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
        public override bool Equals(object? obj)
        {
            var point = obj as Point;
            return point != null ? _x == point._x && _y == point._y : false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }
}