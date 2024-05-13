using Cars.Models;
using Cars.Repository.Interface;
using Cars.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Repository
{
    internal class CarRepository : ICarRepository
    {
        private readonly CarContext carContext;

        public CarRepository(CarContext context)
        {
            this.carContext = context;
        }

        public void AddCar(CarModel carModel)
        {
            var carEntity = new Car
            {
                Name = carModel.Name,
                Model = carModel.Model,
                Color = carModel.Color,
                Year = carModel.Year
            };

            carContext.Cars.Add(carEntity);

            carContext.SaveChanges();
        }

 

        public List<Car> GetAllCars()
        {
            List<Car> cars = carContext.Cars.Select(car => car).ToList();
            return cars;
        }

        public List<CarModel> GetSearchCars(string searchTerm)
        {
            var cars = carContext.Cars.ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                cars = cars.Where(car =>
                    car.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    car.Model.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    car.Color.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    car.Year.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return cars.Select(car => new CarModel
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year
            }).ToList();
        }

        public CarsModel GetCarById(int id)
        {
            var carEntity = carContext.Cars.Find(id);
            if (carEntity == null)
            {
                return null; 
            }

            var carModel = new CarsModel
            {
                Id = carEntity.Id,
                Name = carEntity.Name,
                Model = carEntity.Model,
                Color = carEntity.Color,
                Year = carEntity.Year
            };

            return carModel;
        }




        public void UpdateCar(CarModel updatedCar)
        {

            var existingCar = carContext.Cars.Find(updatedCar.Id);

            if (existingCar != null)
            {
                existingCar.Name = updatedCar.Name;
                existingCar.Model = updatedCar.Model;
                existingCar.Color = updatedCar.Color;
                existingCar.Year = updatedCar.Year;

                carContext.Entry(existingCar).State = EntityState.Modified;

                carContext.SaveChanges();
            }
        }

        public void DeleteCar(int id)
        {
            var carEntity = carContext.Cars.Find(id);
            if (carEntity != null)
            {
                carContext.Cars.Remove(carEntity);
                carContext.SaveChanges();
            }
        }
    }
}
