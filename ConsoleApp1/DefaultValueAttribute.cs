namespace ConsoleApp1
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	public class DefaultValueAttribute : Attribute
	{
		private readonly object defaultValue;

		public DefaultValueAttribute(object defaultValue)
		{
			this.defaultValue = defaultValue;
		}

		public object Value => defaultValue;
	}
}
