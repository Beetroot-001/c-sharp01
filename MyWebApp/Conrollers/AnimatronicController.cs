using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Exceptions;
using MyWebApp.Filters;
using MyWebApp.Services;

namespace MyWebApp.Conrollers
{
    [ApiController]
    [Route("api/animatronics")]
    //[CustomAuthorizationFilter]
    public class AnimatronicController : ControllerBase
    {
        private readonly IAnimatronicService _serviceAccessor;

        public AnimatronicController(IAnimatronicService serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animatronics = await _serviceAccessor.GetAll();
            return Ok(animatronics);
        }
        [HttpPost]
        //[SpringtrapExceptionFilter]
        public async Task<IActionResult> CreateAnimatronic([FromBody]Animatronic animatronic)
        {
            try
            {
                await _serviceAccessor.Create(animatronic);
                return Created("", animatronic);
            }
            catch (SpringtrapException ex)
            {   
                return NoContent();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimatronicById([FromQuery]int id)
        {
            var animatronic = await _serviceAccessor.GetById(id);
            return Ok(animatronic);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteAnimatronic([FromQuery]int id)
        {       
            await _serviceAccessor.Delete(id);
            return NoContent();
        }
    }
}
