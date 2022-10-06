
namespace ConsoleApp1
{
    public  class Workers
    {
        public List <string> WorkersName { get; set; }
        public DateTime StartWorkingDay { get; set; }
        public int totalExpirienceInIndustry;
        public DateTime OpenForTask { get; set; }

        public Workers(List<string> workersName, DateTime startWorkingDay, int totalExpirienceInIndustry)
        {
            WorkersName = workersName;
            StartWorkingDay = startWorkingDay;
            this.totalExpirienceInIndustry = totalExpirienceInIndustry; 
        }
    }
}
