using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Rtp.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{

    [HttpGet]
    public ActionResult<string> Get() => 
        Ok("Hello Carlos, We have Joy!");
}
