using Microsoft.AspNetCore.Mvc;
using ValidateAPI.Helpers;
using ValidateAPI.Models;

namespace ValidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        [HttpGet]
        [Route("ValidateEmail")]
        public IActionResult ValidateEmail(string email)
        {
            var valid = Email.IsEmailValid(email);
            if (valid == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("ValidatePhoneNumber")]
        public IActionResult ValidatePhoneNumber(string phoneNumber)
        {
            var result = ValidateAPI.Helpers.PhoneNumber.IsPhoneNumberValid(phoneNumber);
            return Ok(result);
        }

    }
}
