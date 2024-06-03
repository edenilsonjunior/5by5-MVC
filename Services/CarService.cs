using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService() { _carRepository = new CarRepository(); }

        public bool Insert(Car car) => _carRepository.Insert(car);


        public bool Updade(Car car) => _carRepository.Updade(car);


        public bool Delete(int id) => _carRepository.Delete(id);

        public List<Car> GetAll() => _carRepository.GetAll();

        public Car? Get(int id) => _carRepository.Get(id);

    }
}
