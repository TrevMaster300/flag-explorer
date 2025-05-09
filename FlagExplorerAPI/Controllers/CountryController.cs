using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using FlagExplorerAPI.Models;

namespace FlagExplorerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
                var data = JArray.Parse(response);

                var countries = data.Select(c => new Country
                {
                    Name = (string)c["name"]?["common"] ?? "N/A",
                    Flag = (string)c["flags"]?["png"] ?? ""
                });

                return Ok(countries);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Failed to reach external API: {ex.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("countries/{name}")]
        public async Task<IActionResult> GetCountryDetails(string name)
        {
            HttpResponseMessage response;
            try
            {
                // Use GetAsync so we can inspect the upstream status code
                response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}");
            }
            catch (HttpRequestException ex)
            {
                // network or DNS failures → 503
                return StatusCode(503, $"Could not contact external API: {ex.Message}");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // produces a NotFoundObjectResult
                return NotFound(new { Message = $"No data found for '{name}'." });
            }

            if (!response.IsSuccessStatusCode)
            {
                // any other non-200 → bubble up the status
                return StatusCode((int)response.StatusCode,
                    $"External API returned {(int)response.StatusCode} {response.ReasonPhrase}");
            }

            // 200 OK → parse and return details
            var json = await response.Content.ReadAsStringAsync();
            var data = JArray.Parse(json).First;

            var details = new CountryDetails
            {
                Name = (string?)data["name"]?["common"] ?? "N/A",
                Capital = (string?)data["capital"]?.First ?? "N/A",
                Population = (long?)data["population"] ?? 0,
                Flag = (string?)data["flags"]?["png"] ?? ""
            };

            return Ok(details);
        }
    }
}
