using Microsoft.AspNetCore.Mvc;
using ValidateAPI.Helpers;
using ValidateAPI.Models;

namespace ValidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly ILogger _logger;
        public ValidateController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ValidateEmail")]
        public IActionResult ValidateEmail(string email)
        {
            _logger.LogInformation($"action=validateEmail email={email}");
            var valid = Email.IsEmailValid(email);
            if (valid == true)
            {
                _logger.LogInformation($"action = validateEmail msg='{email} is correct'");
                return Ok();
            }
            _logger.LogWarning($"action = validateEmail msg='{email} is not correct'");
            return BadRequest();
        }

        [HttpGet]
        [Route("ValidatePhoneNumber")]
        public IActionResult ValidatePhoneNumber(string phoneNumber)
        {
            _logger.LogInformation($"action=validateEmail phoneNumber={phoneNumber}");
            var result = ValidateAPI.Helpers.PhoneNumber.IsPhoneNumberValid(phoneNumber);
            if(result == true)
            {
                return Ok(result);
            }
            _logger.LogWarning($"action=validateEmail msg='{phoneNumber} is not correct'");
            return BadRequest();
        }

        [HttpGet]
        [Route("ValidateLength")]
        public IActionResult ValidateLength(string word)
        {
            _logger.LogInformation($"action=validateLenght word={word}");
            var result = Lenght.IsLengthValid(word);
            if (result == true)
            {
                _logger.LogInformation($"action=validateLenght msg='string lenght is valid'");
                return Ok();
            }
            _logger.LogWarning($"action=validateLenght msg='{word} is not valid'");
            return BadRequest();
        }

        [HttpPost]
        [Route("ValidateHostHeader")]
        public IActionResult ValidateHostHeader()
        {
            _logger.LogInformation($"action=ValidateHostHeader");
            var headers = this.Request.Headers.ToDictionary(x => x.Key, x => x.Value);
            if (headers.ContainsKey("Host"))
            {
                _logger.LogInformation($"action=ValidateHostHeader msg='header is valid'");
                return Ok();
            }
            _logger.LogWarning($"action=ValidateHostHeader msg='header is not valid'");
            return BadRequest();
        }
    }
}
