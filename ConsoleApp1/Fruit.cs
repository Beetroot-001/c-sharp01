using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Fruit
    {
        private Point _point;

        public Point Point => _point;

        private Fruit(Point point)
        {
            _point = point;
            _point.State = Point.PointState.FRUIT;
        }

        public static Fruit CreateFruit(int boardSizeX, int boardSizeY)
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            return new Fruit(new Point(rand.Next(4, boardSizeX), rand.Next(1, boardSizeY)));
        }
    }
}
