using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace DaprRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BindingController : ControllerBase
{
    private readonly ILogger<BindingController> _logger;

    public BindingController(ILogger<BindingController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost("/checkout")]
    public ActionResult<string> getCheckout([FromBody] int orderId)
    {
        // Console.WriteLine("Received Message: " + orderId);
        return "CID" + orderId;
    }
}
