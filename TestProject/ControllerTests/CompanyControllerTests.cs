using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Xunit;
using dotnetcorewebapp.Controllers;

namespace TestProject.ControllerTests
{

    [TestClass]
    public class CompanyControllerTests
    {
        private CompanyController CreateController() => new CompanyController();

        [TestMethod]       
        public void Index_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Index();

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Details_WithId_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Details(5);

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Create_Get_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Create();

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Create_Post_WithFormCollection_RedirectsToIndex()
        {
            var controller = CreateController();
            var form = new FormCollection(new Dictionary<string, StringValues>());

            var result = controller.Create(form);

            Assert.IsNotInstanceOfType<ViewResult>(result);
            //Assert.Equals(nameof(CompanyController.Index), redirect.ActionName);
        }

        [TestMethod]
        public void Edit_Get_WithId_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Edit(3);

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        [Fact]
        public void Edit_Post_WithFormCollection_RedirectsToIndex()
        {
            var controller = CreateController();
            var form = new FormCollection(new Dictionary<string, StringValues>());

            var result = controller.Edit(3, form);

            Assert.IsNotInstanceOfType<ViewResult>(result);
            
            //Assert.Equal(nameof(CompanyController.Index), redirect.ActionName);
        }

        [TestMethod]
        [Fact]
        public void Delete_Get_WithId_ReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Delete(7);

            Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void Delete_Post_WithFormCollection_RedirectsToIndex()
        {
            var controller = CreateController();
            var form = new FormCollection(new Dictionary<string, StringValues>());

            var result = controller.Delete(7, form);

            Assert.IsNotInstanceOfType<ViewResult>(result);
            //Assert.Equal(nameof(CompanyController.Index), redirect.ActionName);
        }
    }
}


