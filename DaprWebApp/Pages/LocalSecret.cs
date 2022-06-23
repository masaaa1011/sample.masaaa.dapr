using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaprWebApp.Pages;

public class LocalSecretModel : PageModel
{
    private readonly ILogger<StateFrontModel> _logger;
    private readonly DaprClient _daprClient;

    public LocalSecretModel(ILogger<StateFrontModel> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    public async Task OnGet()
    {
        var secret = await _daprClient.GetSecretAsync("localsecretstore", "secret2");

        _logger.LogInformation($"#######################################################");
        _logger.LogInformation($"secret: {System.Text.Json.JsonSerializer.Serialize(secret)}");
        _logger.LogInformation($"#######################################################");
        
        ViewData["secretData"] = System.Text.Json.JsonSerializer.Serialize(secret);
    }
}