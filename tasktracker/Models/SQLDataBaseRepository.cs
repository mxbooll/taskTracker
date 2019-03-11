using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace tasktracker.Models
{
    public class SQLDataBaseRepository : IRepository
    {
        private TaskTrDBEntitiesContext db;

        public SQLDataBaseRepository()
        {
            this.db = new TaskTrDBEntitiesContext();
        }

        public IEnumerable<HistoryTable> GetDataBaseListHistory()
        {
            return db.HistoryTables;
        }

        public IEnumerable<StoryTable> GetDataBaseListStory()
        {
            return db.StoryTables;
        }

        public StoryTable GetStoryTable(int id)
        {
            return db.StoryTables.Find(id);
        }

        public void Create(StoryTable storyTable)
        {
            DateTime tm = DateTime.Now;
            string statusDefault = "Открыта";

            StoryTable tb1 = new StoryTable();
            tb1.Status = statusDefault;
            tb1.Story = storyTable.Story;
            tb1.Time_enter = tm;

            db.StoryTables.Add(tb1);
            db.SaveChanges();

        }

        public void Create(HistoryTable historyTable)
        {
            DateTime tm = DateTime.Now;

            HistoryTable history = new HistoryTable();
            history.Status = historyTable.Status;
            history.Story_id = historyTable.ID;
            history.Time_enter = tm;
            history.Comment = historyTable.Comment;
            db.HistoryTables.Add(history);
            db.SaveChanges();

            var item = db.StoryTables.Where(x => x.ID == historyTable.ID).First();
            item.Status = historyTable.Status;
            db.SaveChanges();
        }

        public void Update(int id)
        {
            db.Entry(db.StoryTables.Find(id)).State = EntityState.Modified;
        }

        public void Update(StoryTable storyTable)
        {
            db.Entry(storyTable).State = EntityState.Modified;
        }

        public void Update(HistoryTable historyTable)
        {
            db.Entry(historyTable).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            StoryTable storyTable = db.StoryTables.Find(id);
            if (storyTable == null) return;
            db.StoryTables.Remove(storyTable);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StoryTable> GetStory(string stat)
        {
            if (stat == "All")
            {
                var item2 = db.StoryTables.ToList();
                return item2;
            }
            var item = db.StoryTables.Where(x => x.Status == stat).ToList();

            return item;
        }
    }
}