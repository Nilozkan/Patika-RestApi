

using RestApi.Models;

namespace RestApi.Services
{
    public class FakeCarService : ICarService
    {
        private readonly List<Car> _cars = new()
        {
            new Car { Id = 1, Brand = "Ford", Model = "Courier", Year = 2017, Color = "White", Price = 600000 },
            new Car { Id = 2, Brand = "Volkswagen", Model = "Polo", Year = 2020, Color = "Black", Price = 850000 },
            new Car { Id = 3, Brand = "Renault", Model = "Clio", Year = 2022, Color = "Gray", Price = 820000 }
        };
        public Car Add(Car car)
        {
            car.Id = _cars.Any() ? _cars.Max(c => c.Id) + 1 : 1;
            _cars.Add(car);
            return car;
        }

        public bool Delete(int id)
        {
            var car = GetById(id);
            if (car == null) return false;

            return _cars.Remove(car);
        }

        public IEnumerable<Car> GetAll()
        {
           return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public Car Update(int id, Car updatedCar)
        {
            var existingCar = GetById(id);
            if (existingCar == null) return null;

            existingCar.Brand = updatedCar.Brand;
            existingCar.Model = updatedCar.Model;
            existingCar.Year = updatedCar.Year;
            existingCar.Color = updatedCar.Color;
            existingCar.Price = updatedCar.Price;

            return existingCar;
        }

        public Car UpdatePrice(int id, decimal price)
        {
             var existingCar = GetById(id);
            if (existingCar == null) return null;

            existingCar.Price = price;
            return existingCar;
        }
    }
}