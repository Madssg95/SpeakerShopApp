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
    public class BrandsController : ControllerBase
    {

        private readonly IBrandService _brandService;


        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> Get(Filter filter)
        {
            try
            {
                return Ok(_brandService.ReadAllBrands(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Brand> Get(int id)
        {
            try
            {
                return Ok(_brandService.ReadBrandByIdIncludeSpeakers(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Brand> Post([FromBody] Brand brand)
        {
            try
            {
                return Ok(_brandService.CreateBrand(brand));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Brand> Put(int id, [FromBody] Brand brand)
        {
            try
            {
                return Ok(_brandService.UpdateBrand(brand));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Brand> Delete(int id)
        {
            try
            {
                return Ok(_brandService.DeleteBrand(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}