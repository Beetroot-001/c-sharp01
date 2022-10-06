
namespace ConsoleApp1
{
    internal class Honda: Car
    {
        public string label { get; }
        public int inventYear { get; set; }  

        public Honda(string label, int inventYear) : base(inventYear)
        {
            this.label = label;
        }

    }
}
