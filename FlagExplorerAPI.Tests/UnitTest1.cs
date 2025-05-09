using Xunit;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FlagExplorerAPI.Controllers;
using FlagExplorerAPI.Models;

namespace FlagExplorerAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetCountries_ReturnsOkResult_WithListOfCountries()
        {
            // Arrange
            var mockJson = "[{\"name\":{\"common\":\"Botswana\"},\"flags\":{\"png\":\"https://flagcdn.com/w320/bw.png\"}}]";

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync", 
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(mockJson)
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var controller = new CountryController(httpClient);

            // Act
            var result = await controller.GetCountries();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var countries = Assert.IsAssignableFrom<IEnumerable<Country>>(okResult.Value);
            Assert.NotEmpty(countries);
        }

        [Fact]
        public async Task GetCountries_Returns503_OnHttpRequestException()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ThrowsAsync(new HttpRequestException("Network error"));

            var httpClient = new HttpClient(handlerMock.Object);
            var controller = new CountryController(httpClient);

            // Act
            var result = await controller.GetCountries();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(503, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetCountryDetails_ReturnsNotFound_ForInvalidCountry()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("[]")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var controller = new CountryController(httpClient);

            // Act
            var result = await controller.GetCountryDetails("invalid-country");

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains("No data found", notFoundResult.Value?.ToString());
        }
    }
}
