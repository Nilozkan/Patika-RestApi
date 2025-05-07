using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using FluentValidation.Results;
using RestApi.Services;
using RestApi.Attributes;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IValidator<Car> _validator;

        public CarController(ICarService carService, IValidator<Car> validator){
            _carService = carService;
            _validator = validator;
        }
        private static List<Car> CarList = new List<Car>()
        {
            new Car
            {
                Id=1,
                Brand = "Ford",
                Model = "Courier",
                Year = 2017,
                Color = "White",
                Price = 600000
            },
            new Car
            {
                Id=2,
                Brand = "Volkswagen",
                Model = "Polo",
                Year = 2020,
                Color = "Black",
                Price = 850000
            },
            new Car
            {
                Id=3,
                Brand = "Renault",
                Model = "Clio",
                Year = 2022,
                Color = "Gray",
                Price = 820000
            }

        };
         [HttpGet("all")]
         [FakeAuthorize]
         public IActionResult GetCars(){
           return Ok(_carService.GetAll());
         }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetById(id);
            if (car == null)
                return NotFound(new { message = "Car not found" });

            return Ok(car);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            var validationResult = _validator.Validate(car);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var createdCar = _carService.Add(car);
            return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car updatedCar)
        {
            var validationResult = _validator.Validate(updatedCar);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = _carService.Update(id, updatedCar);
            if (result==null)
                return NotFound(new { message = "Car not found" });

            return Ok(updatedCar);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] decimal newPrice)
        {
            var result = _carService.UpdatePrice(id, newPrice);
            if (result==null)
                return NotFound(new { message = "Car not found" });

            return Ok(new { message = "Price updated successfully" });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var result = _carService.Delete(id);
            if (!result)
                return NotFound(new { message = "Car not found" });

            return NoContent();
        }
    }
    
}