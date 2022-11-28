using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SimpleServer.Models;
using SimpleServer.Models.Api;
using SimpleServer.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace SimpleServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonDbContext _persons;

        public PersonsController(PersonDbContext persons)
        {
            _persons = persons;
        }

        /// <summary>
        /// Get everybody
        /// </summary>
        /// <returns>All persons</returns>
        /// <response code="200">Returns all persons</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(Person[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> All(CancellationToken cancellationToken) => 
            Ok(await _persons.People.ToArrayAsync(cancellationToken));

        /// <summary>
        /// Get persons by id
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <returns>Person if it found</returns>
        /// <response code="200">Returns person</response>
        /// <response code="404">Returns Id</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        public async Task<IActionResult >ById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var person = await _persons.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return person == null
                ? NotFound(id)
                : Ok(person);
        }

        /// <summary>
        /// Creates person
        /// </summary>
        /// <param name="request">Create person request</param>
        /// <returns>Id of created person</returns>
        /// <response code="201">Returns Id of created person</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(CreatePersonResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var id = await _persons.People.AnyAsync(cancellationToken) 
                ? await _persons.People.MaxAsync(x => x.Id, cancellationToken) + 1 
                : 1;

            await _persons.AddAsync(new Person
            {
                Age = request.Age,
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                Id = id,
                LastName = request.LastName,
                Verified = request.Verified
            }, cancellationToken);

            await _persons.SaveChangesAsync(cancellationToken);

            return StatusCode(StatusCodes.Status201Created, new CreatePersonResponse
            {
                Id = id
            });
        }

        /// <summary>
        /// Updates person
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <param name="request">Update params</param>
        /// <returns>Updated fields</returns>
        /// <response code="200">Returns updated fields</response>
        /// <response code="404">Returns Id</response>
        /// <response code="500">Returns error message</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UpdatePersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UpdatePersonInternalServerResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonRequest request, 
            CancellationToken cancellationToken)
        {
            var person = await _persons.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (person == null)
            {
                return NotFound(id);
            }

            var personType = typeof(Person);
            var changedProperties = new List<string>();
            foreach (var propertyInfo in request.GetType().GetProperties())
            {
                var fieldValue = propertyInfo.GetValue(request);

                if (fieldValue != null)
                {
                    var destinationProperty = personType.GetProperty(propertyInfo.Name);
                    if (destinationProperty == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new UpdatePersonInternalServerResponse
                            {
                                Message = $"Property {propertyInfo.Name} not found in {personType.Name} type"
                            });
                    }

                    destinationProperty.SetValue(person, fieldValue);
                    changedProperties.Add(destinationProperty.Name);
                }
            }

            if (changedProperties.Any())
            {
                await _persons.SaveChangesAsync(cancellationToken);
            }

            return Ok(new UpdatePersonResponse
            {
                UpdatedFields = changedProperties.ToArray()
            });
        }

        /// <summary>
        /// Delete person
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <returns>Nothing</returns>
        /// <response code="204"></response>
        /// <response code="404">Returns Id</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            var person = await _persons.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (person == null)
            {
                return NotFound(id);
            }

            _persons.Remove(person);
            await _persons.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
