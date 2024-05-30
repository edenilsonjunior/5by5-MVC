using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService() { _carRepository = new CarRepository(); }

        public bool Insert(Car car)
        {
            return _carRepository.Insert(car);
        }

        public bool Updade(Car car)
        {
            return _carRepository.Updade(car);
        }

        public bool Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car Get(int id)
        {
            return _carRepository.Get(id);
        }
    }
}
