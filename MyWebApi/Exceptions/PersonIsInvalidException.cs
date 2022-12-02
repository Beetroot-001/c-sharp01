namespace MyWebApi.Exceptions
{
	public class PersonIsInvalidException : Exception
	{
		public PersonIsInvalidException(string message) : base(message)
		{

		}
	}
}
