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
    public class PaymentsController : ControllerBase
    {
        ICardService _cardService;
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService, ICardService cardService)
        {
            _paymentService = paymentService;
            _cardService = cardService;
        }
        [HttpPost("Payment")]
        public IActionResult Payment(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("GetCardsByCustomerId")]
        public IActionResult GetCardsByCustomerId(int customerId)
        {
            var result = _cardService.GetCardsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
