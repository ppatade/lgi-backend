using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumCalc.Model;

namespace PremiumCalc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public MotorController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetQuote")]
        public QuoteResponse Post([FromBody] QuoteRequest request)
        {
            double basePremium = 5;
            if (request.Idv>100)
                 basePremium = (request.Idv * 0.05);
            double coverPremium = (request.ElectronicCover ? basePremium * 0.05 : 0.00) +
                (request.TheftCover ? basePremium * 0.05 : 0.00) +
                (request.BreakdownCover ? basePremium * 0.05 : 0.00);

            QuoteResponse response = new QuoteResponse();

            response.CustomerName = request.CustomerName;
            response.Idv = request.Idv;
            response.Product = request.Product;
            response.Email = request.Email;
            response.Mobile= request.Mobile;
            response.ReferenceId = request.ReferenceId;

            response.QuoteNo = System.Guid.NewGuid().ToString();
            response.Premium = Math.Round(basePremium + coverPremium,2);
            response.Taxes = Math.Round(response.Premium * 0.2,2);

            return response;

        }
    }
}
