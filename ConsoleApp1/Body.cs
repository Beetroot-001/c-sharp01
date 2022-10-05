namespace ConsoleApp1
{
    public class Body
    {
        private string bodyType;

        public Body(string bType)
        {
            throw new System.NotImplementedException();
        }

        public string BodyType
        {
            get => bodyType;
            set
            {
                this.bodyType = value;
            }
        }
    }
}