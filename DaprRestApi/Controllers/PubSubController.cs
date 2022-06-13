using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace DaprRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PubSubController : ControllerBase
{
    private readonly ILogger<PubSubController> _logger;

    public PubSubController(ILogger<PubSubController> logger)
    {
        _logger = logger;
    }
    
    [Topic("pubsub", "newData")]
    [HttpPost("/data")]
    public void Post(Data data)    
    {
        _logger.LogInformation($"#######################################################");
        _logger.LogInformation($"subscribed: {System.Text.Json.JsonSerializer.Serialize(data)}");
        _logger.LogInformation($"#######################################################");
    }
}
