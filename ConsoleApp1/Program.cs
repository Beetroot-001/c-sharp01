// metod returns max value amoung all parameters
var t = MaxValueReturn(1, 3);
Console.WriteLine("Max value is: "+ t);
// metod returns min value amoung all parameters
var k = MinValueReturn(4, 2);
Console.WriteLine("Min value is: " + k);
//TrySumIfOdd
int x;
int y;
int z;
var c = TrySumIfOdd(out x, out y, out z);
Console.WriteLine($"result: {c}, sum: {z}");
//The last task
int resultMaxValue = MaxValue(5, 9, 6);
Console.WriteLine("MaxValue:" + resultMaxValue);
int resultMinValue = MinValue(5, 9, 6);
Console.WriteLine("MinValue:" + resultMinValue);

static int MaxValueReturn(int a, int b)
{
    int c;
    c = a > b ? a : b;
    return c;
}
static int MinValueReturn(int a, int b)
{
    int c;
    c = a < b ? a : b;
    return c;
}
 bool TrySumIfOdd(out int a,out int b,out int sum)
{
    sum = 0;
    b = 2;
    a = 2;
    sum = a + b;
    if (sum % 2 == 1) {  return true; }
    return false; 
}
  int MaxValue( int a,  int b, int c)
{
    int max1 = Math.Max(a, b);
    int max2= Math.Max(max1, b);
    return max2;
}
int MinValue(int a, int b, int c)
{
    int min1 = Math.Min(a, b);
    int min2 = Math.Min(min1, b);
    return min2;
}
