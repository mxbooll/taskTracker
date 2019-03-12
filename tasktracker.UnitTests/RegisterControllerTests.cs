using NSubstitute;
using NUnit.Framework;
using System;
using System.Web.Mvc;
using tasktracker.Controllers;
using tasktracker.Models;

namespace Tests
{
    [TestFixture]
    public class RegisterControllerTests : RegisterController
    {
        public readonly IRepository ClassStub;

        public RegisterControllerTests()
        {
            ClassStub = Substitute.For<IRepository>();
        }

        protected override IRepository _db => ClassStub;

        /// <summary>
        /// Проверка, что метод SetDataInDatabase() возвращает тип RedirectToRouteResult
        /// </summary>
        [Test]
        public void SetDataInDatabase_Call_ShouldReturnRedirectToRouteResult()
        {
            //arrange
            StoryTable storyTable = new StoryTable();
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.SetDataInDatabase(storyTable);
            //assert
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
            Assert.IsNotNull(result);

        }

        /// <summary>
        /// Проверка, что метод SetDataInDatabase(StoryTable storyTable) с параметром null возвращает тип ViewResult
        /// </summary>
        [Test]
        public void SetDataInDatabase_Return_ShouldReturnView()
        {
            //arrange
            StoryTable storyTable = null;
            var controller = new RegisterController(ClassStub);
            //act
            var result = controller.SetDataInDatabase(storyTable);
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));

        }

        /// <summary>
        /// Проверка, что метод Edit(HistoryTable historyTable) с параметром null возвращает тип ViewResult
        /// </summary>
        [Test]
        public void Edit_NullModel_ShouldReturnView()
        {
            //arrange
            HistoryTable historyTable = null;
            var controller = new RegisterController(ClassStub);
            //int id = 1;
            //act
            var result = controller.Edit(historyTable);
            //assert
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        /// <summary>
        /// Проверка, что метод Edit(HistoryTable historyTable) возвращает тип RedirectToRouteResult
        /// </summary>
        [Test]
        public void Edit_Model_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            var historyTable = new HistoryTable();
            //act
            var result = controller.Edit(historyTable) as RedirectToRouteResult;
            //assert
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Вызов метода Create() из SetDataInDatabase(StoryTable storyTable)
        /// </summary>
        [Test]
        public void Create_CallTestFromSetDataInDatabase()
        {
            StoryTable storyTable = new StoryTable();

            var analyzer = new RegisterControllerTests();
            var sut = analyzer.SetDataInDatabase(storyTable);
            analyzer.ClassStub
                .Received(1)
                .Create(storyTable);
        }

        /// <summary>
        /// Вызов метода Create() из Edit(HistoryTable historyTable)
        /// </summary>
        [Test]
        public void Create_CallTestFromEdit()
        {
            HistoryTable historyTable = new HistoryTable();

            var analyzer = new RegisterControllerTests();
            var sut = analyzer.Edit(historyTable);
            analyzer.ClassStub
                .Received(1)
                .Create(historyTable);
        }

        /// <summary>
        /// Вызов метода Delete() из Delete(int id)
        /// </summary>
        [Test]
        public void Delete_CallTestFromDelete()
        {
            int id = 0;

            var analyzer = new RegisterControllerTests();
            var sut = analyzer.Delete(id);
            analyzer.ClassStub
                .Received(1)
                .Delete(id);
        }

        /// <summary>
        /// Вызов метода GetStory() из Sort(string stat)
        /// </summary>
        [Test]
        public void GetStory_CallTest()
        {
            string stat = "Открыта";

            var analyzer = new RegisterControllerTests();
            var sut = analyzer.Sort(stat);
            analyzer.ClassStub
                .Received(1)
                .GetStory(stat);
        }

        /// <summary>
        /// Вызов метода GetDataBaseListStory() из SortDateUp()
        /// </summary>
        [Test]
        public void GetDataBaseListStory_CallTestFromSortDateUp()
        {
            var analyzer = new RegisterControllerTests();
            var sut = analyzer.SortDateUp();
            analyzer.ClassStub
                .Received(1)
                .GetDataBaseListStory();
        }

        /// <summary>
        /// Вызов метода GetDataBaseListStory() из SortDateUp()
        /// </summary>
        [Test]
        public void GetDataBaseListStory_CallTestFromSortDateDown()
        {
            var analyzer = new RegisterControllerTests();
            var sut = analyzer.SortDateDown();
            analyzer.ClassStub
                .Received(1)
                .GetDataBaseListStory();
        }

        /// <summary>
        /// Вызов метода GetHistoryModel() из ShowDataBaseForHistory()
        /// </summary>
        [Test]
        public void GetHistoryModel_CallTest()
        {
            var analyzer = new RegisterControllerTests();
            var sut = analyzer.ShowDataBaseForHistory();
            analyzer.ClassStub
                .Received(1)
                .GetHistoryModel();
        }
    }
}