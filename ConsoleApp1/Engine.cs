namespace ConsoleApp1
{
    public class Engine
    {
        private string engineModel;
        private string engineType;

        public Engine(string engineModel, string engineType)
        {
            EngineModel = engineModel;
            EngineType = engineType;
        }

        public string EngineModel
        {
            get => engineModel;
            set
            {
                this.engineModel = value;
            }
        }

        public string EngineType
        {
            get => engineType;
            set
            {
                this.engineType = value;
            }
        }
    }
}