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
            Assert.IsNotNull(result);

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
        /// Проверка, что метод Edit() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void Edit_NullModel_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            //int id = 1;
            //act
            var result = controller.Edit(null);
            //assert
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

        /// <summary>
        /// Проверка, что метод Edit() возвращает тип ViewResult
        /// </summary>
        [Test]
        public void Edit_Model_ShouldReturnView()
        {
            //arrange
            var controller = new RegisterController(ClassStub);
            int id = 1;
            var model = new HistoryTable();
            //act
            var result = controller.Edit(model) as RedirectToRouteResult;
            //assert
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
            Assert.IsNotNull(result);
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

        /// <summary>
        /// 
        /// </summary>
        [Test]
        //[Ignore("Тест не доделан")]
        public void GetStoryTable_ReturnParameters()
        {
            StoryTable storyTable = new StoryTable { ID = 1, Status = "Открыта", Story = "Первая заявка", Time_enter = new DateTime(2019, 03, 11, 08, 24, 30, 750) };
            ClassStub.Create(storyTable);
            StoryTable storyTable2 = new StoryTable { ID = 2, Status = "Решена", Story = "Вторая заявка", Time_enter = new DateTime(2019, 03, 12, 08, 24, 30, 750) };
            ClassStub.Create(storyTable2);
            StoryTable storyTable3 = new StoryTable { ID = 3, Status = "Возврат", Story = "Третья заявка", Time_enter = new DateTime(2019, 03, 13, 08, 24, 30, 750) };
            ClassStub.Create(storyTable3);

            ClassStub.GetStoryTable(1).Returns(storyTable);

        }
    }
}