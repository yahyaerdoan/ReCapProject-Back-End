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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetByCarBrandId(int id)
        {
            var result = _brandService.GetByCarBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);                    
        }
        [HttpPost("Add")]
        public IActionResult Add(Brand brand) 
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Brand brand) 
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);        
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Brand brand) 
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
