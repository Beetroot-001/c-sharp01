namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Subject math = new Subject("Math");
            Subject biology = new Subject("Biology");
            Subject chemistry = new Subject("Chemistry");

			Teacher petrovych = new Teacher("Ivan petrovych", math);
			Teacher ivanych = new Teacher("Kyryl Ivanych", biology);
			Teacher zaharovna = new Teacher("Klara Zaharovna", chemistry);

			Student kyryl = new Student("Kyryl");
			Student petro = new Student("Petro");

			School school40 = new School("School #40");
			school40.AddNewTeacher(petrovych, ivanych, zaharovna);
			school40.AddNewStudent(kyryl, petro);
			school40.AddNewSubject(math, biology, chemistry);

			
			
		
		

        }
	}
}