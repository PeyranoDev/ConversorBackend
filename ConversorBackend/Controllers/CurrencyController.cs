using Common.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace ConversorBackend.Controllers
{
    [Route("api/currency")]  
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPut]  
        [Authorize] 
        public IActionResult UpdateCurrency([FromBody] CurrencyForUpdateDTO dto)
        {
            var isAdminClaim = User.Claims.FirstOrDefault(c => c.Type == "isAdmin");

            if (isAdminClaim.Value != "True")
            {
                return Forbid();
            }

            try
            {
                _currencyService.UpdateCurrency(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            return NoContent(); 
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_currencyService.Get());
        }
    }
}