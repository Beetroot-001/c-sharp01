using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class sbas_homework_19_linq
    {
        /*
           finish all tasks from lesson using LinqExample.zip and do next:

        1. find out who is located farthest north/south/west/east using latitude/longitude data
        2. find max and min distance between 2 persons
        3. find 2 persons whos ‘about’ have the most same words
        4. find persons with same friends (compare by friend’s name)

        */

        public static void Mhedod()
        {
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //1
            var farthestNorth = people.MaxBy(x=> x.Latitude);
            var farthestSouth = people.MinBy(x=> x.Latitude);
            var farthestWest = people.MaxBy(x=> x.Longitude);
            var farthestEast = people.MinBy(x=> x.Longitude);

            //2

            var maxDistance = people.Select(x => people.Select(y => (x.Latitude - y.Latitude)).ToList()).ToList();// вкладений цикл
            var maxDistance1 = people.Select(x => people.Select(y => (x.Longitude - y.Longitude)).ToList()).ToList();

            //3
            var twoPerson = people.GroupBy(x => x.About.Split(' '));

        }

    }
}
