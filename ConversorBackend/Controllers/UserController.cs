
using Common.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using System.Security.Claims;

namespace ConversorBackend.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserForCreateDTO dto)
        {
            try
            {
                _userServices.AddUser(dto);
            }
            catch (Exception ex)
            {
                return BadRequest("This user already exists...");
            }
            return Created();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteSelf()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            try
            {
                _userServices.Delete(userId);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...");
            }
            return NoContent();
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            var isAdminClaim = User.Claims.FirstOrDefault(c => c.Type == "isAdmin");

            if (isAdminClaim.Value != "True")
            {
                return Forbid();
            }

            try
            {
                _userServices.Delete(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var isAdminClaim = User.Claims.FirstOrDefault(c => c.Type == "isAdmin");

            if (isAdminClaim.Value != "True")
            {
                return Forbid();
            }
            return Ok(_userServices.Get());
        }

        [Authorize]
        [HttpGet("details")]
        public IActionResult GetUserDetails()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok(_userServices.GetUserDetails(userId));
        }

        [Authorize]
        [HttpPut("subscription/manage/{subscriptionId}")]
        public IActionResult UpdateSubscription([FromRoute] int subscriptionId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            try
            {
                _userServices.UpdateUserSubscription(userId, subscriptionId);
                return Ok(new { message = "Subscription updated successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{userId}/change-subscription/{subscriptionId}")]
        public IActionResult UpdateUserSubscription(int userId, int subscriptionId)
        {
            var isAdminClaim = User.Claims.FirstOrDefault(c => c.Type == "isAdmin");

            if (isAdminClaim.Value != "True")
            {
                return Forbid();
            }
            try
            {
                _userServices.UpdateUserSubscription(userId, subscriptionId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
