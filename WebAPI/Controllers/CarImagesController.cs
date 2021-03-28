using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.Get(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

/*
[HttpPost("update")]
public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int imageId)
{
    var carImage = _carImageService.GetByImageId(imageId).Data;
    var result = _carImageService.Update(file, carImage);
    if (result.Success)
    {
        return Ok(result);
    }
    return BadRequest(result);
}*/
/*
[HttpPut("update")]
public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
{
    if (file == null)
    {
        return BadRequest("Boş resim gönderemezsin");
    }
    IResult result = _carImageService.Update(carImage, file);
    if (result.Success)
    {
        return Ok(result);
    }
    return BadRequest(result);
}*/
/*
[HttpGet("getbyimageid")]
public IActionResult GetByImageId([FromForm(Name = ("Id"))] int imageId)
{
    var result = _carImageService.GetById(imageId);
    if (result.Success)
    {
        return Ok(result);
    }
    return BadRequest(result);
}
*/
/*

[HttpDelete("deletebycarid")]
public IActionResult DeleteByCarId(int carId)
{
    IResult result = _carImageService.DeleteByCarId(carId);
    if (result.Success)
    {
        return Ok(result);
    }
    return BadRequest(result);
}*/
/*[HttpGet("getimagesbycarid")]
public IActionResult GetImagesByCarId([FromForm(Name = ("CarId"))] int carId)
{
    var result = _carImageService.GetImagesByCarId(carId);
    if (result.Success)
    {
        return Ok(result);
    }
    return BadRequest(result);
}*/