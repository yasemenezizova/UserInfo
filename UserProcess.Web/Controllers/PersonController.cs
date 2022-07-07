using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserProcess.Entity.Dtos;
using UserProcess.Services.Abstract;
using UserProcess.Shared.Helpers;
using System.Linq;
namespace UserProcess.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService categoryService)
        {
            _personService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> SavePerson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return BadRequest("Error has occured!");

            var person = JsonConvert.DeserializeObject<PersonAddDto>(json, new CustomJsonConvertor(typeof(PersonAddDto)));
            var result = await _personService.Add(person, "Admin");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson(string filter)
        {

            var people = await _personService.GetAll(filter);
            string json = JsonConvert.SerializeObject(people, Formatting.Indented, new CustomJsonConvertor(typeof(List<PersonGetDto>)));

            if (json.Equals("[]"))
                return BadRequest("Data was not found!");

            return Ok(json);

        }
    }
}
