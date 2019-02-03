using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;

namespace tasktracker.Models
{
    public class RegisterController : Controller
    {

        TaskTrDBEntities db = new TaskTrDBEntities();

        public ActionResult SetDataInDatabase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetDataInDatabase(StoryTable model)
        {
            DateTime tm = DateTime.Now;
            string statusDefault = "Открыта";

            StoryTable tb1 = new StoryTable();
            tb1.Status = statusDefault;
            tb1.Story = model.Story;
            tb1.Time_enter = tm;
            db.StoryTable.Add(tb1);
            db.SaveChanges();
            return RedirectToAction("ShowDataBaseForUser");

            //return View();
        }

        public ActionResult ShowDataBaseForUser()
        {
            var item = db.StoryTable.ToList();
            return View(item);
        }

        public ActionResult ShowDataBaseForHistory()
        {
            var result =
                (from F in db.StoryTable
                 join FT in db.HistoryTable on F.ID equals FT.Story_id
                 //where (il.ProdId == p.Id) && (il.IngId == ing.Id)
                 select new ShowDataBaseForHistoryModel { Story = F.Story, Status = FT.Status, Time = FT.Time_enter, Comment = FT.Comment }).ToList();
            return View(result);
        }

        public ActionResult Sort(string stat)
        {
            if (stat == "All")
            {
                var item2 = db.StoryTable.ToList();
                return View("ShowDataBaseForUser", item2);
            }
            var item = db.StoryTable.Where(x => x.Status == stat).ToList();
            return View("ShowDataBaseForUser", item);
        }

        [HttpGet]
        public ActionResult SortDate(string dateBegin, string dateEnd)
        {
            DateTime dBegin = DateTime.ParseExact(dateBegin, "yyyyMdd", null);
            DateTime dEnd = DateTime.ParseExact(dateEnd, "yyyyMdd", null);

            var item = db.StoryTable.Where(x => x.Time_enter > dBegin && x.Time_enter < dEnd).ToList();
            return View("ShowDataBaseForUser", item);
        }

        public ActionResult Delete(int id)
        {
            var item = db.StoryTable.Where(x => x.ID == id).First();
            db.StoryTable.Remove(item);
            db.SaveChanges();
            var item2 = db.StoryTable.ToList();
            return View("ShowDataBaseForUser", item2);
        }


        public ActionResult Edit(int id)
        {
            var item = db.StoryTable.Where(x => x.ID == id).First();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(HistoryTable model)
        {
            DateTime tm = DateTime.Now;

            HistoryTable tb1 = new HistoryTable();
            tb1.Status = model.Status;
            tb1.Story_id = model.ID;
            tb1.Time_enter = tm;
            tb1.Comment = model.Comment;
            db.HistoryTable.Add(tb1);
            db.SaveChanges();

            var item = db.StoryTable.Where(x => x.ID == model.ID).First();
            item.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("ShowDataBaseForUser");
        }
    }
}