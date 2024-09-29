using JOIEnergy.Domain;
using JOIEnergy.Services;
using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Controllers
{
    [Route("cost-calc")]
    public class CostCalculatorController : Controller
    {
         private readonly IAccountService _accountService;
         private readonly IPricePlanService _pricePlanService;

        public CostCalculatorController(IAccountService accountService, IPricePlanService pricePlanService)
        {
            this._accountService = accountService;
            this._pricePlanService = pricePlanService;
        }

        [HttpGet("test/{smartMeterId}")]
        public ObjectResult CalcCost(string smartMeterId)
        {
            //test ซะบ้างว่า connection ใช้ได้ยัง ????
            string pricePlanId = _accountService.GetPricePlanIdForSmartMeterId(smartMeterId);
            ElectricityCost result = _pricePlanService.CostCalc(smartMeterId, pricePlanId);

            return new ObjectResult(result);
            //return new ObjectResult("success");


        }

    }

}