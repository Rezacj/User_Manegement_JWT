using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_Manegement_System.Controllers
{
    [Authorize] // Autorize For acess to that API
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("get-product")]
        public IActionResult getproduct()
        {
            var Product = new
            {
                Name = "برنج ایرانی",
                Price = "1.200.000.000"
            };
            return Ok(Product);
        }
    }
}
