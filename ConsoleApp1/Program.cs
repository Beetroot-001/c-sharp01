using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer john = new Customer("John", "john@gmail.com", "12345678");
            Customer brian = new Customer("Brian", "brian@gmail.com", "password");
            LoginForm loginForm = new LoginForm();
            loginForm.Register(john);
            loginForm.CheckRegStatus(john);
            loginForm.CheckRegStatus(brian);
            Tshirt red = new Tshirt();
            Bin bin1 = new Bin(john, loginForm);
            bin1.AddGoods(red, 6);
            bin1.RemoveGoods(red, 5);
            IGoods red1 = red;            
            bin1.Checkout();
            Receipt receipt = new Receipt(bin1);
        }
        public class Tshirt : IGoods
        {
            public string Name { get; set; } = "Shirt";
            public int weight { get; set; } = 10;
            public int uahValue { get; set; } = 100;
            public bool isAvalableNow { get; set; } = true;
            public int quantity { get; set; } = 5;            
        }
    }
}