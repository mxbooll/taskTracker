﻿using System;

namespace tasktracker.Models
{
    public class ShowDataBaseForHistoryModel
    {
        public string Story { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
    }
}