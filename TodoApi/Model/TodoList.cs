﻿using System.Collections.Generic;

namespace TodoApi
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TodoItem> Items { get; set; }
    }
}
