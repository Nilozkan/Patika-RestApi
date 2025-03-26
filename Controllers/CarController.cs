using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using FluentValidation.Results;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IValidator<Car> _validator;

        public CarController(IValidator<Car> validator){
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
         [HttpGet]
         public IActionResult GetCars(){
             return Ok(CarList);
         }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = CarList.Where(x=> x.Id == id).SingleOrDefault();
            return Ok(car);
        }

        // [HttpGet]
        // public IActionResult GetFromQuery([FromQuery] string id)
        // {
        //     var car = CarList.Where(x=>x.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return Ok(car);
        // }
        
        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            car.Id = CarList.Any() ? CarList.Max(c => c.Id) + 1 : 1;
            FluentValidation.Results.ValidationResult validationResult = _validator.Validate(car);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            CarList.Add(car);
                return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car putCar)
        {
            var car = CarList.FirstOrDefault(x => x.Id == id);
            if (car == null) return NotFound(new{message ="Car not found"});

            car.Brand = putCar.Brand;
            car.Model = putCar.Model;
            car.Year = putCar.Year;
            car.Color = putCar.Color;
            car.Price = putCar.Price;
            return Ok(car);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] decimal newPrice)
        {
            var car = CarList.FirstOrDefault(x => x.Id==id);
            if (car == null) return NotFound();

            car.Price = newPrice;
            return Ok(car);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = CarList.FirstOrDefault(c => c.Id==id);
            if(car == null) return NotFound();

            CarList.Remove(car);
            return NoContent();
        }
    }
    
}