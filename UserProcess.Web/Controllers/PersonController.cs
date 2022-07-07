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
            if (!string.IsNullOrEmpty(json))
            {
                var person = JsonConvert.DeserializeObject<PersonAddDto>(json, new CustomJsonConvertor(typeof(PersonAddDto)));
                var result = await _personService.Add(person, "Admin");
                return Ok(result);
            }
            else
                return BadRequest("Error has occured!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson(string filter)
        {
            IList<PersonGetDto> people;

            string json = string.Empty;
           
                var filteredParams = JsonConvert.DeserializeObject<PersonGetDto>(filter, new CustomJsonConvertor(typeof(PersonGetDto)));
                if (filteredParams == null)
                {
                    people = await _personService.GetAll();
                    json = JsonConvert.SerializeObject(people, Formatting.Indented, new CustomJsonConvertor(typeof(PersonGetDto)));
                }
                else
                {
                people=filteredParams.FirstName!=null? await _personService.GetAll().ToList()
                }



                return Ok(json);
            
            //else
            //    return BadRequest("There is no person");
        }
    }
}
