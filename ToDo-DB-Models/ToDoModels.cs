using System;

namespace ToDo_DB_Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string TodoName { get; set; }

        public string TodoDescription { get; set; }

        public string Status { get; set; }
    }
}
