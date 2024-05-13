using System;
using System.Runtime.ConstrainedExecution;
using Cars.Models;

namespace Cars.Abstraction
{
    public interface ICarService
    {
        List<CarModel> GetAllCars();
        List<CarModel> GetAllCars(string searchTerm);
        CarModel GetCarById(int id);
        void UpdateCar(CarModel updatedCar);

     
        //List<CarsModel> GetAllCars();
        //List<CarsModel> GetCars(string searchTerm);
        void AddCar(CarModel car);
        //void UpdateCar(CarsModel car);
        void DeleteCar(int id);
    }
}