namespace MyWebApp.Exceptions
{
    public class SpringtrapException : Exception
    {
        public SpringtrapException()
        {
            
        }
        public SpringtrapException(string message) : base(message)
        { }

        public SpringtrapException(string message, Exception inner) : base(message, inner)
        { }
    }
}
