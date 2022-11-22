namespace ConsoleApp1
{
    public class Person
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        private int Age { get; set; } = 0;

        private void AgeOne()
        {
            Age++;
        }
    }
}