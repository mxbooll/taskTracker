using System;

namespace tasktracker.Models
{
    public interface IStoryTable
    {
        int ID { get; set; }
        string Status { get; set; }
        string Story { get; set; }
        DateTime Time_enter { get; set; }
    }
}