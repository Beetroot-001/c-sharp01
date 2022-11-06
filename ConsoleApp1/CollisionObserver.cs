using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class CollisionObserver
    {
        static public Action<Snake, int> collisionDetection;

        static CollisionObserver()
        {
            collisionDetection += CheckBounds;
            collisionDetection += SnakeCollision;
        }

        static public void CheckBounds(Snake snake, int size)
        {
            if (snake.Head.X == 0 || snake.Head.X == size || snake.Head.Y == 0 || snake.Head.Y == size)
                snake.Kill();
        }

        static public void SnakeCollision(Snake snake, int size)
        {
            var body = snake.Body.FindAll((part) => part.X == snake.Head.X && part.Y == snake.Head.Y).ToList();
            if (body.Count() > 1)
                snake.Kill();
        }
    }
}
