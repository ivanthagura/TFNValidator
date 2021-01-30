using System.Net;
using System.Threading.Tasks;
using API.Configurations;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TFNController : ControllerBase
    {
        private readonly IOptions<AttemptsConfigurations> _attemptsConfig;
        private readonly IOptions<WeightingFactorConfigurations> _weightingConfig;

        public IAttemptsService _attemptsService { get; set; }
        public IWeightingFactorService _weightingFactorService { get; set; }
        public ITFNService _tfnService { get; set; }

        public TFNController(IOptions<AttemptsConfigurations> attemptsConfig, IOptions<WeightingFactorConfigurations> weightingConfig,
            IAttemptsService attemptsService, IWeightingFactorService weightingFactorService, ITFNService tfnService)
        {
            _attemptsConfig = attemptsConfig;
            _weightingConfig = weightingConfig;
            _attemptsService = attemptsService;
            _weightingFactorService = weightingFactorService;
            _tfnService = tfnService;
        }

        [HttpGet("{tfnNumber}")]
        public async Task<IActionResult> GetTFNValidations(string tfnNumber)
        {
            bool isValid = false;
            var isNumeric = int.TryParse(tfnNumber, out int tfn);

            // validate if tfn is numbers
            if (!isNumeric)
            {
                ModelState.AddModelError("Invalid TFN number format", "The TFN number should only contain numerals");
                return BadRequest(ModelState);
            }

            // tfn should only contain 8 or 9 digits
            if (!(tfnNumber.Length == (int)Digits.Eight || tfnNumber.Length == (int)Digits.Nine))
            {
                ModelState.AddModelError("Invalid TFN number length", $"The TFN number should only contain {Digits.Eight} or {Digits.Nine} digits");
                return BadRequest(ModelState);
            }

            // validate if consecutive attempts are linked
            var attemptsFile = _attemptsConfig.Value.FilePath + _attemptsConfig.Value.FileName;
            var attemptsWithinGivenTime = await _attemptsService.GetAttempts(attemptsFile, 30);
            if (attemptsWithinGivenTime.Count > 2)
            {
                var attemptsAreLinked = _attemptsService.CheckIfLinking(tfnNumber, attemptsWithinGivenTime);
                if (attemptsAreLinked)
                {
                    ModelState.AddModelError("Multiple attempts detected", "Validation tool does not allow multiple attempts within a give time frame");
                    return BadRequest(ModelState);
                }
            }

            var weightingFactorFile = _weightingConfig.Value.FilePath + _weightingConfig.Value.FileName.Replace('#', tfnNumber.Length.ToString()[0]);
            var weightingFactors = _weightingFactorService.GetWeightingFactors(weightingFactorFile);
            if (weightingFactors == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            isValid = _tfnService.ValidateTFN(tfnNumber, weightingFactors);

            _attemptsService.AddAttempt(attemptsFile, tfnNumber);

            return Ok(isValid);
        }
    }
}