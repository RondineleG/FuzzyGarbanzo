using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyGarbanzo.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MainController : ControllerBase
    {

    }
}