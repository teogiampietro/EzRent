using Microsoft.AspNetCore.Mvc;

namespace EzRent.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase
{
    protected string GetUserId()
        => this.User.Claims.First(i => i.Type == "sid").Value;
}