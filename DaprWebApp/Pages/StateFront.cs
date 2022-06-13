using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaprWebApp.Pages;

public class StateFrontModel : PageModel
{
    private readonly ILogger<StateFrontModel> _logger;
    private readonly DaprClient _daprClient;

    public StateFrontModel(ILogger<StateFrontModel> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    public async Task OnGet()
    {
        await _daprClient.SaveStateAsync<Data>("statestore", "key", new Data(){ Id = Guid.NewGuid(), Occured = DateTime.Now });
        var  data = await _daprClient.GetStateAsync<Data>("statestore", "key");

        ViewData["StateFrontData"] = data;
    }
}