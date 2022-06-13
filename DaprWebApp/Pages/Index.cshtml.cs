using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaprWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DaprClient _daprClient;

    public IndexModel(ILogger<IndexModel> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    public async Task OnGet()
    {
        var forecasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
            HttpMethod.Get,
            "daprrestapi",
            "weatherforecast");

        ViewData["WeatherForecastData"] = forecasts;
    }
}