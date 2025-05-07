using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;

namespace RestApi.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        Car Add(Car car);
        Car Update(int id, Car updatedCar);
        Car UpdatePrice(int id, decimal price);
        bool Delete(int id);
    }
}