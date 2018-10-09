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
            try
            {
                return Ok(_speakerService.ReadSpeakerByIdIncludeBrand(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Speaker> Post([FromBody] Speaker speaker)
        {
            try
            {
                return Ok(_speakerService.CreateSpeaker(speaker));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            

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