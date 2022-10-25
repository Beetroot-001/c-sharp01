using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {   
        static void Main(string[] args)
        {
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            var personEast = people.Where(x => x.Longitude == people
            .Select((x) => x.Longitude).Max()).Single();
            var personNorth = people.Where(x => x.Latitude == people
            .Select((x) => x.Latitude).Max()).Single();
            var personWest = people.Where(x => x.Longitude == people
            .Select((x) => x.Longitude).Min()).Single();
            var personSouth = people.Where(x => x.Latitude == people
            .Select((x) => x.Latitude).Min()).Single();

            Console.WriteLine($"{personNorth.Name} is located farthest north Position: ({personNorth.Longitude}), ({personNorth.Latitude})");
            Console.WriteLine($"{personSouth.Name} is located farthest south Position: ({personSouth.Longitude}), ({personSouth.Latitude})");
            Console.WriteLine($"{personWest.Name} is located farthest west Position: ({personWest.Longitude}), ({personWest.Latitude})");
            Console.WriteLine($"{personEast.Name} is located farthest east Position: ({personEast.Longitude}), ({personEast.Latitude})");

            List<Person> personList = people.ToList();
            int index = 0;
            var farthest = people.Where((x) =>
            index != personList.Count()).Select((x) =>
            Math.Sqrt(Math.Pow(personList[index++].Longitude - x.Longitude, 2) + Math.Pow(personList[index++].Latitude - x.Latitude, 2))).Max();
            index = 0;
            var nearest = people.Where((x) =>
            index != personList.Count()).Select((x) =>
            Math.Sqrt(Math.Pow(personList[index++].Longitude - x.Longitude, 2) + Math.Pow(personList[index++].Latitude - x.Latitude, 2))).Min();

            Console.WriteLine(farthest);
            Console.WriteLine(nearest);



            Console.WriteLine();


            //var males = people.Count(x => x.Gender == Gender.Male);
            //Console.WriteLine($"Males: {males}");

            //var females = people.Count(x => x.Gender == Gender.Female);
            //Console.WriteLine($"Females: {females}");

            //var grouped = people.GroupBy(x => x.Gender).ToDictionary(x => x.Key, x => x.Count());
            //foreach (var item in grouped)
            //{
            //    Console.WriteLine(item);
            //}

            //var youngest = people.Min(x => x.Age);
            //var youngestPerson = people.MinBy(x => x.Age);
            //Console.WriteLine($"Min age: {youngest}");

            //var oldest = people.Max(x => x.Age);
            //var oldestPerson = people.MaxBy(x => x.Age);
            //Console.WriteLine($"Max age: {oldest}");

            //var averageAge = people.Average(x =>
            //{
            //    return x.Age;
            //});
            //Console.WriteLine($"Average age: {averageAge}");

            //var nearestPerson = people.Select(x => new { Number = Math.Abs(x.Age - averageAge), person = x }).OrderBy(x => x.Number).First().person;
            //Console.WriteLine();

            //var isActiveCount = people.Count(x => x.IsActive);
            //Console.WriteLine($"IsActiveCount : {isActiveCount}");

            //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            //var averageBalance = people.Average(x => decimal.Parse(x.Balance.Substring(1)));
            //Console.WriteLine($"Avarage balance: {averageBalance}");

            //var eyeColorGroups = people
            //    .GroupBy(x => x.EyeColor)
            //    .ToDictionary(x => x.Key, x => new { Count = x.Count() });

            //var peopleWithSameName = people.GroupBy(x => x.Name.Split(' ')[0])
            //    .ToDictionary(x => x.Key, x => x);

            //var firstRegistered = people.MinBy(x => x.Registered);
            //var lastRegistered = people.MaxBy(x => x.Registered);

            ////[ [1,2], [3], [4]]
            //// [1,2,3,4]
            ////
            //var friends = people.Select(x => x.Friends);

            //var res = Enumerable.Range(1, 5).Aggregate((current, accum) => current * accum);

            //Console.WriteLine();
        }

    }
}
