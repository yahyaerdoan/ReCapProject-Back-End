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
    public class CardPaymentsController : ControllerBase
    {
        private readonly ICardPaymentService _cardPaymentService;

        public CardPaymentsController(ICardPaymentService cardPaymentService)
        {
            _cardPaymentService = cardPaymentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cardPaymentService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCardPaymetsByCustomerId")]
        public IActionResult GetCardPaymetsByCustomerId(int customerId)
        {
            var result = _cardPaymentService.GetCardPaymetsByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Add(cardPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Update(cardPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Delete(cardPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
    }
}
