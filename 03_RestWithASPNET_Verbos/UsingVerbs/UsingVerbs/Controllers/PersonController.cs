using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingVerbs.Model;
using UsingVerbs.Services;

namespace UsingVerbs.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            personService = _personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) 
                return NotFound();
            else
                return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Update(person));
        }


        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
                return NoContent();
        }



    }
}
