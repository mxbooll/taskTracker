using System;
using System.Collections.Generic;

namespace tasktracker.Models
{
    //паттерн репозиторий
    public interface IRepository : IDisposable
    {
        void Create(StoryTable storyTable);
        void Create(HistoryTable historyTable);
        void Delete(int id);
        IEnumerable<HistoryTable> GetDataBaseListHistory();
        IEnumerable<StoryTable> GetDataBaseListStory();
        StoryTable GetStoryTable(int id);
        void Save();
        void Update(StoryTable storyTable);
        void Update(HistoryTable historyTable);
        void Update(int id);
        IEnumerable<StoryTable> GetStory(string stat);
    }
}