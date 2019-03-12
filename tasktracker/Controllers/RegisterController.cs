using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using tasktracker.Models;

namespace tasktracker.Controllers
{
    public class RegisterController : Controller
    {

        protected virtual IRepository _db { get; } = new SQLDataBaseRepository();

        public RegisterController()
        {
            _db = new SQLDataBaseRepository();
        }

        public RegisterController(IRepository db)
        {
            _db = db;
        }

        /// <summary>
        /// Вывести таблицу с заявками
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowDataBaseForUser()
        {
            return View(_db.GetDataBaseListStory().ToList());
        }

        public ActionResult SetDataInDatabase()
        {
            return View();
        }

        /// <summary>
        /// Подача новой заявки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetDataInDatabase(StoryTable model)
        {
            if (ModelState.IsValid && model != null)
            {
                _db.Create(model);
                return RedirectToAction("ShowDataBaseForUser");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            StoryTable storyTable = _db.GetStoryTable(id);
            return View(storyTable);
        }

        /// <summary>
        /// Внесения изменений в статус заявки
        /// </summary>
        /// <param name="historyTable"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(HistoryTable historyTable)
        {
            if (ModelState.IsValid && historyTable != null)
            //if (ModelState.IsValid)
            {
                _db.Create(historyTable);
                return RedirectToAction("ShowDataBaseForUser");
            }
            return View();
        }

        /// <summary>
        /// Удаление заявки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            _db.Delete(id);
            return RedirectToAction("ShowDataBaseForUser");
        }

        /// <summary>
        /// Вывод таблицы с историей изменений
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowDataBaseForHistory()
        {
            var result = _db.GetHistoryModel();
            return View(result);
        }

        /// <summary>
        /// Сортировка по статусу
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public ActionResult Sort(string stat)
        {
            var item = _db.GetStory(stat);
            return View("ShowDataBaseForUser", item);
        }

        /// <summary>
        /// Сортировка по дате от самой ранней до последней
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SortDateUp()
        {
            var result = _db.GetDataBaseListStory()
                .OrderBy(x => x.Time_enter)
                .ToList();
            return View("ShowDataBaseForUser", result);
        }

        /// <summary>
        /// Сортировка по дате от последней до самой ранней
        /// </summary>
        /// <returns></returns>
        public ActionResult SortDateDown()
        {
            var result = _db.GetDataBaseListStory()
                .OrderByDescending(x => x.Time_enter)
                .ToList();
            return View("ShowDataBaseForUser", result);
        }
    }
}