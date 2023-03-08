using Microsoft.AspNetCore.Mvc;
using UpSwot_Test.BLL.Models;
using UpSwot_Test.BLL.Services;

namespace UpSwot_Test.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost("check-person")]
        public async Task<IActionResult> Check(CheckPersonModel names)
        {
            var checkedPerson = await personService.CheckPersonAsync(names)
                .ConfigureAwait(false);

            if (checkedPerson == null)
            {
                return NotFound();
            }

            return Ok(checkedPerson.Value);
        }

        [HttpGet("person")]
        [ResponseCache(CacheProfileName = "Cache5Mins")]
        public async Task<IActionResult> Get(string name)
        {
            var person = await personService.GetPersonAsync(name).ConfigureAwait(false);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
