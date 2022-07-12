using Microsoft.AspNetCore.Mvc;
using ValidateAPI.Helpers;
using ValidateAPI.Models;

namespace ValidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly ILogger<ValidateController> _logger;
        public ValidateController(ILogger<ValidateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Check email validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Boolean data type</returns>
        [HttpGet]
        [Route("ValidateEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ValidateEmail(string email)
        {
            try
            {
                _logger.LogInformation($"action=validateEmail email={email}");
                var valid = Email.IsEmailValid(email);
                if (valid == true)
                {
                    _logger.LogInformation($"action=validateEmail msg='{email} is correct'");
                    return Ok();
                }
                _logger.LogWarning($"action=validateEmail msg='{email} is not correct'");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"action=validateEmail msg='{ex.Message}'", ex);
                return StatusCode(500);
            }
          
        }

        /// <summary>
        /// Check phone number validation
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>Boolean data type</returns>
        [HttpGet]
        [Route("ValidatePhoneNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ValidatePhoneNumber(string phoneNumber)
        {
            try
            {
                _logger.LogInformation($"action=validatePhoneNumber phoneNumber={phoneNumber}");
                var result = ValidateAPI.Helpers.PhoneNumber.IsPhoneNumberValid(phoneNumber);
                if (result == true)
                {
                    return Ok(result);
                }
                _logger.LogWarning($"action=validatePhoneNumber msg='{phoneNumber} is not correct'");
                return BadRequest();
            }
            catch(Exception ex)
            {
                _logger.LogError($"action=validatePhoneNumber msg='{ex.Message}'", ex);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Check length validation
        /// </summary>
        /// <param name="word"></param>
        /// <param name="length"></param>
        /// <returns>Boolean data type</returns>
        [HttpGet]
        [Route("ValidateLength")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ValidateLength(string word, int length)
        {
            try
            {
                _logger.LogInformation($"action=validateLength word={word}");
                var result = Length.IsLengthValid(word, length);
                if (result == true)
                {
                    _logger.LogInformation($"action=validateLength msg='string lenght is valid'");
                    return Ok();
                }
                _logger.LogWarning($"action=validateLength msg='{word} is not valid'");
                return BadRequest();
            }
            catch(Exception ex)
            {
                _logger.LogError($"action=validateLength msg='{ex.Message}'", ex);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Check host - HTTP header validation
        /// </summary>
        /// <returns>Boolean data type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("ValidateHostHeader")]
        public IActionResult ValidateHostHeader()
        {
            try
            {
                _logger.LogInformation($"action=ValidateHostHeader");
                var headers = this.Request.Headers.ToDictionary(x => x.Key, x => x.Value);
                if (headers.ContainsKey("Host"))
                {
                    _logger.LogInformation($"action=validateHostHeader msg='header is valid'");
                    return Ok();
                }
                _logger.LogWarning($"action=validateHostHeader msg='header is not valid'");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"action=validateHostHeader msg='{ex.Message}'", ex);
                return StatusCode(500);
            }
        }   
    }
}
