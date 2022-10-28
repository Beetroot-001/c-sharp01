using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Calculating between two points using longitude and latitude
        /// </summary>
        /// <param name="xLong">Longitude of first element</param>
        /// <param name="xLat">Latitude of the first element</param>
        /// <param name="yLong">Longitude of second element</param>
        /// <param name="yLat">Latitude of second element</param>
        /// <returns>Distance</returns>
        static double Distance(double xLong, double xLat, double yLong, double yLat) => Math.Sqrt(Math.Pow(xLong - yLong, 2) + Math.Pow(xLat - yLat, 2));

        /// <summary>
        /// Calculate normalized similarity number of two strings.
        /// </summary>
        /// <param name="source">First string</param>
        /// <param name="target">Second string</param>
        /// <returns>Normalized similarity number</returns>
        static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            var sourceSplit = source.Split(new[] { ' ', ',', '.' });
            var targetSplit = target.Split(new[] { ' ', ',', '.' });

            int result = 0;

            foreach (var word in sourceSplit)
            {
                if (targetSplit.Contains(word))
                    result++;
            }

            return (1.0 - ((double)result / (double)Math.Max(source.Length, target.Length)));
        }
        /// <summary>
        /// Comparing friend lists
        /// </summary>
        /// <param name="x">First list</param>
        /// <param name="y">Second list</param>
        /// <returns>True if lists are equal, otherwise false</returns>
        static bool CompareFriends(Friend[] x, Friend[] y)
        {
            if(x.Length != y.Length) return false;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].Name != y[i].Name)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            var personEast = people.MaxBy(x => x.Longitude);
            var personNorth = people.MaxBy(x => x.Latitude);
            var personWest = people.MinBy(x => x.Longitude);
            var personSouth = people.MinBy(x => x.Latitude);

            Console.WriteLine($"{personNorth.Name} is located farthest north Position: ({personNorth.Longitude}), ({personNorth.Latitude})");
            Console.WriteLine($"{personSouth.Name} is located farthest south Position: ({personSouth.Longitude}), ({personSouth.Latitude})");
            Console.WriteLine($"{personWest.Name} is located farthest west Position: ({personWest.Longitude}), ({personWest.Latitude})");
            Console.WriteLine($"{personEast.Name} is located farthest east Position: ({personEast.Longitude}), ({personEast.Latitude})");

            var distanceMax = people.Select(x => people
                                    .Select(y => Distance(xLat: x.Latitude, yLat: y.Latitude, xLong: x.Longitude, yLong: y.Longitude))
                                    .Max()).Max();
            var distanceMin = people.Select(x => people
                                    .Select(y => Distance(xLat: x.Latitude, yLat: y.Latitude, xLong: x.Longitude, yLong: y.Longitude)).OrderBy(x => x).Skip(1)
                                    .Min()).Min();

            Console.WriteLine($"Maximum distance: {distanceMax}");
            Console.WriteLine($"Minimum distance: {distanceMin}");

            var aboutsMax = people.Select(x => people
                                  .Select(y => new { similarity = CalculateSimilarity(x.About, y.About), people = (first: x, second: y) })
                                  .OrderByDescending(x => x.similarity).Skip(1).First())
                                  .MaxBy(x => x.similarity);

            Console.WriteLine($"{aboutsMax.similarity} {aboutsMax.people.first.Name} {aboutsMax.people.second.Name}");

            var sameFriend = people.SelectMany(x => people
                                   .Select(y => new { personPair = (first: x, second: y), equals = CompareFriends(x.Friends, y.Friends) && x.Name != y.Name })
                                   .Where(y => y.equals));

            Console.WriteLine();
        }

    }
}
