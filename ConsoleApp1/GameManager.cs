namespace ConsoleApp1
{
    class GameManager
    {
        private Board _board;

        private GameManager()
        {
            _board = new Board();
        }

        public static GameManager Start()
        {
            return new GameManager();
        }

        public void Update()
        {
            _board.Render();
        }
    }
}