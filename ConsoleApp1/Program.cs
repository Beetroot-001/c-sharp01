
/* Create a program that will start with declaration of two constants (X and Y) 
* and will count the sum of all numbers between these constants. 
* If they are equal then sum should be one of them
*/
 
  int d = 6,
      f = 9;

 if (d < f || f > d) 
   {
   for (int i = d; i <= f; i++) 
   {
    int result = i;
    
    Console.Write(result); 
   }
 } //хотіла спробувати з циклом такеж зробити, але поки не можу зрозуміти як знайти суму, а також зробити так щоб воно рахувало також коли а > b

 int n = Math.Abs(f - d) + 1; 
 if (d < f || d > f) 
 {
  int sum = n * (d + f) / 2;
  Console.WriteLine(sum);
 } else if (d == f) 
 {
  Console.WriteLine(d);
 }

//Read values of X and Y from the console. If output is invalid - write to console Invalid input and exit the program.

int integer;
bool CorrectValue;

do 
{
 Console.Write("Enter any word: ");
 string? SomeWord = Console.ReadLine();
 CorrectValue = int.TryParse(SomeWord, out integer);
} while (!CorrectValue);
  Console.Write("Inccorect value, please press to exit...");
  Console.ReadLine();

/* There are 2 variables.

 * int x = 7;
 * int y = 5;
The task is to swap values for that variables. The result of x should be 5 and y - 7.
 */

int x = 7;
int y = 5;
int AnotherInteger = x;
x = y;
y = AnotherInteger; 

Console.WriteLine($"x: {x}, y: {y}");

/* Find prime numbers in range a..b

 * Example: 

 * a=1;
 * b=5;
 * Output: 2,3,5
 */

int a = 1;
int b = 5;

Console.WriteLine("Prime numbers in current range: ");

for (int i = a; i <= b; i++)
{
  if (IsPrime(i))
  {
    Console.WriteLine(i);
  }
}

static bool IsPrime(int number)
{
    if (number <= 1)
  {
    return false;
  }

    if (number == 1)
  {
    return true;
  }

    for (int i = 2; i < number; i++)
  {
    if (number % i == 0)
      {
        return false;
      }
  }

return true;
} 


