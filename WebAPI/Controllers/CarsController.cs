using Busines.Abstract;
using Busines.Concrete;
using DateAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {       
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int id) 
        {
            var result = _carService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }       
        [HttpGet("GetAll")]
        public IActionResult GetAll()       
        {
            Thread.Sleep(1000);
            var result = _carService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);        
        }
        [HttpGet("GetByCarBrandId")]
        public IActionResult GetByCarBrandId(int id) 
        {
            var result = _carService.GetByCarBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCarColorId")]
        public IActionResult GetByCarColordId(int id)
        {
            var result = _carService.GetByCarColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarByDailyPrice")]
        public IActionResult GetByCarDailyPrice(decimal min, decimal max) 
        {
            var result = _carService.GetByCarDailyPrice(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarAllByBrand")]
        public IActionResult GetAllByCarBrand()
        {
            var result = _carService.GetAllByCarBrand();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByCarDescription")]
        public IActionResult GetAllByCarDescription()
        {
            var result = _carService.GetAllByCarDescription();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Car car) 
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllCarDetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetAllCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
