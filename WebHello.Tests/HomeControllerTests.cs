using WebHello.Controllers;
using WebHello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Moq;

namespace WebHello.Tests
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            Mock<IWebHostEnvironment> envMock = new Mock<IWebHostEnvironment>();
            envMock.Setup(e => e.ContentRootPath).Returns(Path.GetTempPath());

            _controller = new HomeController(envMock.Object);
        }

        [Fact]
        public void Greet_ReturnsRedirect_WhenNameIsEmpty()
        {
            var model = new VisitorModel { Name = "" };

            var result = _controller.Greet(model) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Greet_ReturnsViewResult_WithGreetingMessage()
        {
            var model = new VisitorModel { Name = "Béla" };

            var result = _controller.Greet(model) as ViewResult;

            Assert.NotNull(result);
            Assert.True(_controller.ViewBag.GreetingMessage.ToString().Contains("Béla"));
        }

        [Fact]
        public void Greeting_Changes_ByHour()
        {
            var model = new VisitorModel { Name = "Tesztelő" };

            var result = _controller.Greet(model) as ViewResult;

            string msg = _controller.ViewBag.GreetingMessage;
            Assert.Contains("Tesztelő", msg);
            Assert.True(
                msg.StartsWith("Jó reggelt") ||
                msg.StartsWith("Jó napot") ||
                msg.StartsWith("Jó estét")
            );
        }
    }
}
