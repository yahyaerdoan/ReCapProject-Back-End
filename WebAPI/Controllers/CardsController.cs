using Busines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _CardService;

        public CardsController(ICardService CardService)
        {
            _CardService = CardService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _CardService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCardsByCustomerId")]
        public IActionResult GetCardsByCustomerId(int customerId)
        {
            var result = _CardService.GetCardsByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Card Card)
        {
            var result = _CardService.Add(Card);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Card Card)
        {
            var result = _CardService.Update(Card);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Card Card)
        {
            var result = _CardService.Delete(Card);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
    }
}
