using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    internal class Game
    {
        NewSnake snake;
        Board board;

        private int size;
        private int score = -1; 

        public Game(int size, int speed = 200)
        {
            this.size = size;
            board = new Board(size);
            snake = new NewSnake(size, speed);

            snake.GameEndEvent += GameOver;
            snake.LevelUpEvent += ScoreTable;

            ScoreTable();
        }

        /// <summary>
        /// Start game
        /// </summary>
        public void Start()
        {
            snake.StartMotion();
        }

        /// <summary>
        /// Print the result of the game when it's over
        /// </summary>
        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(size / 4, size / 3);
            Console.WriteLine("Game Over");
            Console.SetCursorPosition((size / 4) - 2, (size / 3) + 1);
            Console.WriteLine($"Total Score: {score}");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Display the current score and snake's speed
        /// </summary>
        private void ScoreTable()
        {
            Console.SetCursorPosition(size + 1, 0);
            Console.WriteLine($"Total score: {++score}");
            Console.SetCursorPosition(size + 1, 1);           
        }

    }
}
