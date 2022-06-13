using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaprWebApp.Pages;

public class PubSubModel : PageModel
{
    private readonly ILogger<PubSubModel> _logger;
    private readonly DaprClient _daprClient;

    public PubSubModel(ILogger<PubSubModel> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    public async Task OnGet()
    {
        await _daprClient.PublishEventAsync<Data>("pubsub", "newData", new Data(){ Id = Guid.NewGuid(), Occured = DateTime.Now });
    }
}