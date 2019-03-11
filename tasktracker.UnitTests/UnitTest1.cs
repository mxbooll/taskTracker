using NSubstitute;
using NUnit.Framework;
using System;
using System.Web.Mvc;
using tasktracker.Models;

namespace Tests
{
    [TestFixture]
    public class ControllersTests : RegisterController
    {
        public readonly IRepository ClassStub;

        public ControllersTests()
        {
            ClassStub = Substitute.For<IRepository>();
        }

        [SetUp]
        public void SetUp()
        {
        }

        /// <summary>
        /// Проверка, что метод ShowDataBaseForUser() возвращает тип ViewResult 
        /// </summary>
        [Test]
        public void ShowDataBaseForUser_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.ShowDataBaseForUser();
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод SetDataInDatabase() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void SetDataInDatabase_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.SetDataInDatabase();
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод Edit() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void Edit_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            int id = 1;
            //act
            var result = controller.Edit(id);
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод ShowDataBaseForHistory() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void ShowDataBaseForHistory_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.ShowDataBaseForHistory();
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод Sort() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void Sort_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            string stat = "";
            //act
            var result = controller.Sort(stat);
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод SortDateUp() возвращает тип ViewResult 
        /// </summary>
        [Test]
        public void SortDateUp_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.SortDateUp();
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод SortDateDown() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void SortDateDown_Call_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.SortDateDown();
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

    }
}