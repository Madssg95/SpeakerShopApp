using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopAppRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {

        private readonly ISpeakerService _speakerService;


        public SpeakersController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Speaker>> Get()
        {
            return _speakerService.ReadAllSpeakers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}