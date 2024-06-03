using Models;
using Services;

namespace Controllers
{
    public class InsuranceController
    {
        private InsuranceService _insuranceService;

        public InsuranceController()
        {
            _insuranceService = new InsuranceService();
        }

        public int Insert(Insurance insurance)
        {
            return _insuranceService.Insert(insurance);
        }
    }
}
