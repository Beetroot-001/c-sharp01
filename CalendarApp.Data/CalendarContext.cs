using CalendarApp.Contracts;
using Newtonsoft.Json;

namespace CalendarApp.Data
{
	public class CalendarContext
	{
		private readonly string filePath;

		public Calendar Calendar { get; set; }

		public CalendarContext(string filePath)
		{
			this.filePath = filePath;
			Load();
		}

		public void Load()
		{
			if (!File.Exists(filePath))
			{
				Calendar = new Calendar();
				return;
			}

			var @json = File.ReadAllText(filePath);
			Calendar = JsonConvert.DeserializeObject<Calendar>(@json);
		}

		public void SaveChanges()
		{
			var json = JsonConvert.SerializeObject(Calendar);
			File.WriteAllText(filePath, json);
		}
	}
}
