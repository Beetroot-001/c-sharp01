using Newtonsoft.Json;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
            var males = people.Count(x => x.Gender == Gender.Male);
            Console.WriteLine($"Males: {males}");
            var females = people.Count(x => x.Gender == Gender.Female);
            Console.WriteLine($"Females: {females}");
            var grouped = people.GroupBy(x => x.Gender).ToDictionary(x => x.Key, x => x.Count());
            foreach (var item in grouped)
            {
                Console.WriteLine(item);
            }
            var youngest = people.Min(x => x.Age);
            var youngestPerson = people.MinBy(x => x.Age);
            Console.WriteLine($"Min age: {youngest}");
            var oldest = people.Max(x => x.Age);
            var oldestPerson = people.MaxBy(x => x.Age);
            Console.WriteLine($"Max age: {oldest}");
            var averageAge = people.Average(x =>
            {
                return x.Age;
            });
            Console.WriteLine($"Average age: {averageAge}");
            var nearestPerson = people.Select(x => new { Number = Math.Abs(x.Age - averageAge), person = x }).OrderBy(x => x.Number).First().person;
            Console.WriteLine();
            var isActiveCount = people.Count(x => x.IsActive);
            Console.WriteLine($"IsActiveCount : {isActiveCount}");
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var averageBalance = people.Average(x => decimal.Parse(x.Balance.Substring(1)));
            Console.WriteLine($"Avarage balance: {averageBalance}");
            var eyeColorGroups = people
                .GroupBy(x => x.EyeColor)
                .ToDictionary(x => x.Key, x => new { Count = x.Count() });
            var peopleWithSameName = people.GroupBy(x => x.Name.Split(' ')[0])
                .ToDictionary(x => x.Key, x => x);
            var firstRegistered = people.MinBy(x => x.Registered);
            var lastRegistered = people.MaxBy(x => x.Registered);
            var friends = people.Select(x => x.Friends);
            var res = Enumerable.Range(1, 5).Aggregate((current, accum) => current * accum);
            Console.WriteLine();
            var mostNorth = people.OrderBy(x => x.Latitude).First();
            var mostSouth = people.OrderByDescending(x => x.Latitude).First();
            var mostEast = people.OrderBy(x => x.Longitude).First();
            var mostWest = people.OrderByDescending(x => x.Longitude).First();
            var closest = people.Select(x => new { Num = Math.Abs(x.Age - averageAge), person = x }).OrderBy(x => x.Num).First().person;

            static int CountSim(string one, string two)
            {
                string[] res1 = one.Split(" ");
                string[] res2 = two.Split(" ");
                var intersect = res1.Intersect(res2);
                return intersect.Count();
            }

            var aboutCompare = people.Select(x => (x, people.MaxBy(x1 => CountSim(x.About, x1.About)))).MaxBy(x => CountSim(x.x.About, x.Item2.About));

            var sortByFriends = people.Join(people, x => true, x => true, (x1, x2) => new
            {
                Person1 = x1,
                Person2 = x2,
            }).Where(x => x.Person1 != x.Person2).Select(x =>
            {
                var personFriend = x.Person1.Friends;
                var personFriend1 = x.Person2.Friends;
                var sameFriends = personFriend.IntersectBy(personFriend1.Select(x => x.Name), y => y.Name).ToList();               
                return new
                {
                    Person1 = x.Person1,
                    Person2 = x.Person2,
                    sameFriends = sameFriends
                };
            });
            var ress = sortByFriends.MaxBy(x => x.sameFriends.Count);
            Console.WriteLine(ress);
            

        }

    }
}
