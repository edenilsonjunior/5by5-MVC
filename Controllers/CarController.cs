using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;
        private InsuranceService _insuranceService;


        public CarController()
        {
            _carService = new CarService();
            _insuranceService = new InsuranceService();
        }

        public bool Insert(Car car)
        {
            car.Insurance.Id = _insuranceService.Insert(car.Insurance);
            return _carService.Insert(car);
        }

        public bool Updade(Car car) => _carService.Updade(car);

        public bool Delete(int id) => _carService.Delete(id);

        public List<Car> GetAll() => _carService.GetAll();

        public Car? Get(int id) => _carService.Get(id);

    }
}
