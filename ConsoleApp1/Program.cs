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
			Teacher zaharovna = new Teacher("Klara Xaharovna", chemistry);



			School school40 = new School("School #40");


			//school40.AddNewToSchool(School.AddNew.teacher, petrovych);



			school40.AddNewTeacher(petrovych, ivanych, zaharovna);

			school40.AddNewToSchool(School.AddNew.teacher, ivanych);

			school40.GetListOfTeachers();

			



        }
	}
}