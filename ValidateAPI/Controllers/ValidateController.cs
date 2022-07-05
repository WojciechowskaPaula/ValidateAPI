using Microsoft.AspNetCore.Mvc;
using ValidateAPI.Helpers;

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
           if(valid == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
