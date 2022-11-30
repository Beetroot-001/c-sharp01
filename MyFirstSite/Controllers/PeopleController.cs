using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Data;
using MyFirstSite.Models;
using System;

namespace MyFirstSite.Controllers
{
    [Route("persons")]
    public class PeopleController : Controller
    {
        private static readonly PeopleContext peopleContext = new PeopleContext();

        public IActionResult Index()
        {
            IEnumerable<Person> people = peopleContext.People.ToList();

			return View(people);
        }

        [HttpGet("create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost("create")]
		public IActionResult Create([FromForm] Person person)
		{
			if (!ModelState.IsValid)
			{
				// 
			}

			peopleContext.People.Add(person);

			peopleContext.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet("{id}/delete")] // people/1/delete?id=1
		public IActionResult Delete([FromRoute] int id)
		{
			var person = peopleContext.People.Find(id);

			return View("Delete12", person);
		}

		[HttpPost("{id}/delete")] // people/1/delete?id=1
		public IActionResult DeletePerson([FromRoute] int id)
		{
			var person = peopleContext.People.Find(id);

			if(person == null)
			{
				return RedirectToAction("Index");
			}

			peopleContext.Remove(person);
			peopleContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
