using Busines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
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
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;      

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;          
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] Image image, [FromForm] IFormFile file)
        {
            var result = _imageService.Add(image, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete([FromForm] Image image)
        {
           
            var result = _imageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetImageByCarId")]
        public IActionResult GetImageByCarId(int id)
        {
            var result = _imageService.GetImageByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
