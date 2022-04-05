using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDo_DB_Context;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ToDoContext _db;
        public ICollection<ToDo_DB_Models.ToDo> Todos { get; set; }
             
        public IndexModel(ILogger<IndexModel> logger, ToDoContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            ViewData["todo"] = _db.ToDos;
            var todos = _db.ToDos.Select(pd => pd);
            Todos = todos.ToList();
        }
    }
}
