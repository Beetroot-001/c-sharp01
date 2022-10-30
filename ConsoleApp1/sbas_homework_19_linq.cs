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
            var farthestNorth = people.MaxBy(x => x.Latitude);
            var farthestSouth = people.MinBy(x => x.Latitude);
            var farthestWest = people.MaxBy(x => x.Longitude);
            var farthestEast = people.MinBy(x => x.Longitude);

            //2
            var distance = people.Join(people, p1 => true, p2 => true, (p1, p2) => new
            {
                Person1 = p1,
                Person2 = p2,
            })
                .Where(x => x.Person1 != x.Person2)
                .Select(x =>
                {
                    var distance12 = Math.Sqrt(Math.Pow(2, (x.Person2.Latitude - x.Person1.Latitude)) + Math.Pow(2, (x.Person2.Longitude - x.Person1.Longitude)));
                    return new
                    {
                        Person1 = x.Person1,
                        Person2 = x.Person2,
                        Distance = distance12,
                    };
                });

            var distanceMax = distance.MaxBy(x => x.Distance);
            var distanceMin = distance.MinBy(x => x.Distance);

            Console.WriteLine($"Person name: {distanceMax.Person1.Name}| ID: {distanceMax.Person1.Id}\nPerson name: {distanceMax.Person2.Name}| ID: {distanceMax.Person2.Id}\nSame Distance:{distanceMax.Distance}");

            Console.WriteLine($"Person name: {distanceMin.Person1.Name}| ID: {distanceMin.Person1.Id}\nPerson name: {distanceMin.Person2.Name}| ID: {distanceMin.Person2.Id}\nSame Distance:{distanceMin.Distance}");

            //3
            var sequense = people.Join(people/*Person (колекція вхідна)*/, p1 => true/*person,(=>) bool*/, p2 => true/*person,(=>) bool*/, (p1, p2) => new //*person, person (=>) a`*/
            {
                Person1 = p1,
                Person2 = p2,// що повертає join? колекцію анонімних класів що ми зробили?
            }/* створюємо анонімний клас? */)
            .Where(x => x.Person1 != x.Person2)
            .Select(x => // перетворюємо кожен елемент попередньої вибірки в новий анонімний клас з виконанням того що в фігурних дужках
            {
                var personAbautwords1 = x.Person1.About.Split(' ');
                var personAbautwords2 = x.Person2.About.Split(' ');

                var sameWords = personAbautwords1.Intersect(personAbautwords2).ToList();

                return new
                {
                    Person1 = x.Person1,
                    Person2 = x.Person2,
                    sameWords = sameWords// створюємо анонімний клас який повертається
                };
            });
            //1 створив масив з двох людуй
            // 2 створив масив виключаючи людей які однакові
            // 3 створив масив перетворених елеменів попереднього масиву по заданій логіці


            var res1 = sequense.MaxBy(x => x.sameWords.Count);
            var res2 = sequense.MinBy(x => x.sameWords.Count);

            Console.WriteLine($"Person name: {res1.Person1.Name}| ID: {res1.Person1.Id}\nPerson name: {res1.Person2.Name}| ID: {res1.Person2.Id}\nSame Words:{res1.sameWords.Count}");

            Console.WriteLine($"Person name: {res2.Person1.Name}| ID: {res2.Person1.Id}\nPerson name: {res2.Person2.Name}| ID: {res2.Person2.Id}\nSame Words:{res2.sameWords.Count}");

            //4 
            var selectionFriends = people.Join(people, p1 => true, p2 => true, (p1, p2) => new
            {
                Person1 = p1,
                Person2 = p2,
            }).ToList()
                .Where(x => x.Person1 != x.Person2)
                .Select(x =>
                {
                    var sameFriends = x.Person1.Friends.Count(p1 => x.Person2.Friends.All(p2 => p1.Id == p2.Id));

                    return new
                    {
                        Person1 = x.Person1,
                        Person2 = x.Person2,
                        sameFriends = sameFriends,
                    };
                });
            var resFriendsMax = selectionFriends.MaxBy(x => x.sameFriends);
            var resFriendsMin = selectionFriends.MinBy(x => x.sameFriends);

            Console.WriteLine($"Person name: {resFriendsMax.Person1.Name}| ID: {resFriendsMax.Person1.Id}\nPerson name: {resFriendsMax.Person2.Name}| ID: {resFriendsMax.Person2.Id}\nSame Friends:{resFriendsMax.sameFriends}");

            Console.WriteLine($"Person name: {resFriendsMin.Person1.Name}| ID: {resFriendsMin.Person1.Id}\nPerson name: {resFriendsMin.Person2.Name}| ID: {resFriendsMin.Person2.Id}\nSame Friends:{resFriendsMin.sameFriends}");
        }
    }
}
