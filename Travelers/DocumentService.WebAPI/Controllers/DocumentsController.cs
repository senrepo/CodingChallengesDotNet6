using System.Threading.Tasks;
using DocumentService.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DocumentsController : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Validate(Document document)
        {
            var messages = document.Validate();

            if(messages.Count > 0)
            {
                return BadRequest(messages);
            }

            return Ok(messages);
        }
    }
}
