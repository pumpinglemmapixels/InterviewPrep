using Microsoft.Extensions.Logging;
using Moq;
using MyRestApi.Controllers;
using MyRestApi.Controllers.Dtos;
using Newtonsoft.Json;
using Prep.Interfaces.Arguments.Application;
using Prep.Interfaces.Common;
using Prep.Interfaces.DataObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace Test.MyRestApi
{
    [TestClass]
    public class Entity1ControllerTests
    {
        private Entity1Controller? controller;

        private Mock<ILogger<Entity1Controller>> logger = new Mock<ILogger<Entity1Controller>>();//make this a globally available static to get for testing
        private Mock<IQuery<GetEntity1ByIdApp, TestEntity1>> getByIdQuery = new Mock<IQuery<GetEntity1ByIdApp, TestEntity1>>();
        private Mock<IQuery<GetAllEntity1App, IEnumerable<TestEntity1>>> getAllQuery = new Mock<IQuery<GetAllEntity1App, IEnumerable<TestEntity1>>>();

        [TestInitialize]
        public void TestInitialize()
        {
            controller = new Entity1Controller(logger.Object, getByIdQuery.Object, getAllQuery.Object);
        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(13)]
        public async Task TestGetById(int input)
        {
            getByIdQuery.Setup(x => x.Get(It.IsAny<GetEntity1ByIdApp>())).ReturnsAsync(
                new CommandResult<TestEntity1>(
                    new TestEntity1(input, "asdf", 1)
                    ));
            Entity1Dto result = await controller.GetById(input);
            Assert.AreEqual(result.Id, input);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            getAllQuery.Setup(x => x.Get(It.IsAny<GetAllEntity1App>())).ReturnsAsync(
                new CommandResult<IEnumerable<TestEntity1>>(
                    new List<TestEntity1> { new TestEntity1(1, "asdf", 1), new TestEntity1(2, "zxcv", 2) }
            ));
            IEnumerable<Entity1Dto> result = await controller.GetAll();
            List<Entity1Dto> listResult = result.ToList();
            Assert.AreEqual(listResult.Count, 2);
        }


        [TestMethod]
        public void EnsureDtoHasRequiredAttributes()
        {
            //do not change this test without versioning the api
            Entity1Dto testEntity1 = new Entity1Dto(1, "asdf", 2);

            Assert.AreEqual(testEntity1.Id, 1);
            Assert.AreEqual(testEntity1.Name, "asdf");
            Assert.AreEqual(testEntity1.Prop1, 2);
        }
    }

}