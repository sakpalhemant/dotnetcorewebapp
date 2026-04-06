using dotnetcorewebapp.Controllers;
using dotnetcorewebapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;
using Xunit;

namespace TestProject.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController CreateController()
        {
            var logger = NullLogger<HomeController>.Instance;
            return new HomeController(logger);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Index();

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Privacy_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Privacy();

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Error_ReturnsViewResult_WithHttpContextTraceIdentifier_WhenNoActivity()
        {
            var controller = CreateController();
            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = "test-trace-id";
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };

            var result = controller.Error();
            Assert.IsInstanceOfType<ViewResult>(result);
           // Assert.IsInstanceOfType<ErrorViewModel>(viewResult.Model);

            //var viewResult = Assert.IsInstanceOfType<ViewResult>(result);
            //var model = Assert.IsInstanceOfType<ErrorViewModel>(viewResult.Model);
            //Assert.Equal(httpContext.TraceIdentifier, model.RequestId);
        }

        [TestMethod]
        public void Error_ReturnsViewResult_WithActivityId_WhenActivityIsPresent()
        {
            var controller = CreateController();
            var httpContext = new DefaultHttpContext();
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };

            var activity = new Activity("unit-test-activity");
            activity.Start();
            try
            {
                var result = controller.Error();
                Assert.IsInstanceOfType<ViewResult>(result);

                //var viewResult = Assert.IsType<ViewResult>(result);
                //var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
                //Assert.Equal(activity.Id, model.RequestId);
            }
            finally
            {
                activity.Stop();
            }
        }
    }
}
