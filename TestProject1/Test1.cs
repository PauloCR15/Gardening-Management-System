using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prueba1.BLL;
using Prueba1.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Prueba1.DAL;
using Models;
using Prueba1;
using Microsoft.EntityFrameworkCore;


namespace TestProject1
    {
        [TestClass]
        public sealed class Test1
        {
            private Mock<ClientBLL> _mockClientBLL = null!;
            private ClientController _controller = null!;

            [TestInitialize]
            public void Setup()
            {
            var options = new DbContextOptionsBuilder<DBContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;
            _mockClientBLL = new Mock<ClientBLL>(MockBehavior.Strict, new ClientDataAccess(new DBContext(options)));
                _controller = new ClientController(_mockClientBLL.Object);
            }

            [TestMethod]
            public void Get_ReturnsClients_WhenClientsExist()
            {
                // Arrange
                var clients = new List<Client> { new Client { ClientID = 1, ClientFullName = "John Doe" } };
                _mockClientBLL.Setup(bll => bll.GetAllClients()).Returns(clients);

                // Act
                var result = _controller.Get();

                // Assert
                var actionResult = result as ActionResult<List<Client>>;
                var okResult = actionResult?.Result as OkObjectResult;
                var returnValue = okResult?.Value as List<Client>;
                Assert.IsNotNull(returnValue);
                Assert.AreEqual(1, returnValue.Count);
            }

            [TestMethod]
            public void Get_ReturnsNotFound_WhenNoClientsExist()
            {
                // Arrange
                _mockClientBLL.Setup(bll => bll.GetAllClients()).Returns(new List<Client>());

                // Act
                var result = _controller.Get();

                // Assert
                var actionResult = result as ActionResult<List<Client>>;
                var notFoundResult = actionResult?.Result as NotFoundObjectResult;
                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual("No clients found.", notFoundResult.Value);
            }

            [TestMethod]
            public void GetByID_ReturnsClient_WhenClientExists()
            {
                // Arrange
                var client = new Client { ClientID = 1, ClientFullName = "John Doe" };
                _mockClientBLL.Setup(bll => bll.GetClientById(1)).Returns(client);

                // Act
                var result = _controller.Get(1);

                // Assert
                var actionResult = result as ActionResult;
                var okResult = actionResult as OkObjectResult;
                var returnValue = okResult?.Value as Client;
                Assert.IsNotNull(returnValue);
                Assert.AreEqual(client.ClientID, returnValue.ClientID);
            }

            [TestMethod]
            public void GetByID_ReturnsNotFound_WhenClientDoesNotExist()
            {
                // Arrange
                _mockClientBLL.Setup(bll => bll.GetClientById(1)).Returns((Client?)null);

                // Act
                var result = _controller.Get(1);

                // Assert
                var actionResult = result as ActionResult;
                var notFoundResult = actionResult as NotFoundObjectResult;
                Assert.IsNotNull(notFoundResult);
                Assert.AreEqual("Client not found", notFoundResult.Value);
            }

            [TestMethod]
            public void Post_AddsClient_ReturnsCreatedAtAction()
            {
                // Arrange
                var client = new Client { ClientID = 1, ClientFullName = "John Doe" };

                // Act
                var result = _controller.Post(client);

                // Assert
                var actionResult = result as ActionResult;
                var createdAtActionResult = actionResult as CreatedAtActionResult;
                var returnValue = createdAtActionResult?.Value as Client;
                Assert.IsNotNull(returnValue);
                Assert.AreEqual(client.ClientID, returnValue.ClientID);
            }

            [TestMethod]
            public void Delete_RemovesClient_ReturnsOk()
            {
                // Act
                var result = _controller.Delete(1);

                // Assert
                var actionResult = result as ActionResult;
                Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            }

            [TestMethod]
            public void Put_UpdatesClient_ReturnsOk()
            {
                // Arrange
                var client = new Client { ClientID = 1, ClientFullName = "John Doe" };

                // Act
                var result = _controller.Put(1, client);

                // Assert
                var actionResult = result as ActionResult;
                Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            }

            [TestMethod]
            public void CheckID_ReturnsTrue_WhenClientExists()
            {
                // Arrange
                _mockClientBLL.Setup(bll => bll.checkID(1)).Returns(true);

                // Act
                var result = _controller.checkID(1);

                // Assert
                var actionResult = result as ActionResult<bool>;
                var okResult = actionResult?.Result as OkObjectResult;
                Assert.IsNotNull(okResult);
                Assert.IsTrue(okResult?.Value as bool?);
            }

            [TestMethod]
            public void CheckID_ReturnsFalse_WhenClientDoesNotExist()
            {
                // Arrange
                _mockClientBLL.Setup(bll => bll.checkID(1)).Returns(false);

                // Act
                var result = _controller.checkID(1);

                // Assert
                var actionResult = result as ActionResult<bool>;
                var okResult = actionResult?.Result as OkObjectResult;
                Assert.IsNotNull(okResult);
                Assert.IsFalse(okResult?.Value as bool?);
            }
        }
    }
