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
        public ActionResult<IEnumerable<Speaker>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_speakerService.ReadAllSpeakers(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Speaker> Get(int id)
        {
            if (id <= 0 )
            {
                return BadRequest("Id skal være over 0");
            }

            return Ok(_speakerService.ReadSpeakerById(id));

           
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Speaker> Post([FromBody] Speaker speaker)
        {
            if (string.IsNullOrEmpty(speaker.SpeakerName))
            {
                return BadRequest("Remember to enter a name!");
            }
            if (speaker.Price<0)
            {
                return BadRequest("Remember to enter a price!");
            }
            if (string.IsNullOrEmpty(speaker.Color))
            {
                return BadRequest("Remember to enter a color!");
            }
            if (string.IsNullOrEmpty(speaker.SpeakerDescription))
            {
                return BadRequest("Remember to enter a description!");
            }
            return _speakerService.CreateSpeaker(speaker);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Speaker> Put(int id, [FromBody] Speaker speaker)
        {
            if (id < 1 || id != speaker.SpeakerId)
            {
                return BadRequest("Id passer ikke!");
            }

            return Ok(_speakerService.UpdateSpeaker(speaker));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Speaker> Delete(int id)
        {
            Speaker speaker = _speakerService.DeleteSpeaker(id);
            if (speaker == null)
            {
                return StatusCode(404, "Kunne ikke finde speaker med id:" + id);
            }
            return Ok($"Speaker with Id: {id} is Deleted");
        }
    }
}