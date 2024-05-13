using Cars.Models;
using Cars.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Repository.Interface
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
        public List<CarModel> GetSearchCars(string searchTerm);
        CarsModel GetCarById(int id);
        void UpdateCar(CarModel carEntity);
        void AddCar(CarModel car);
        void DeleteCar(int id);
    }
}
