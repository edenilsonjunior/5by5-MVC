using Models;
using Repositories;

namespace Services
{
    public class InsuranceService
    {
        private InsuranceRepository _repository;

        public InsuranceService() { _repository = new InsuranceRepository(); }

        public int Insert(Insurance insurance)
        {
            return _repository.Insert(insurance);
        }
    }
}
