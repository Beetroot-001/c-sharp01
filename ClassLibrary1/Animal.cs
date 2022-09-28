namespace ClassLibrary1
{
	class Animal
	{
		private int a;
		protected int speed;

		protected internal int weight;
		private protected int weight2;

		public int NumOfPawns1 { get; set; }
		internal int NumOfPawns2 { get; set; }
		private int NumOfPawns3 { get; set; }

		public Animal()
		{
			NumOfPawns3 = 4;
			var t = this.weight;
		}

		public void Method()
		{

		}
	}
}