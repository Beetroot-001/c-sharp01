namespace CalendarApp.Contracts
{
    [Serializable]
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Meeting> Meetings { get; set; }

        public string Capacity { get; set; }

        public Room()
        {
            Meetings = new List<Meeting>();
        }
    }
}