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

        [FromForm]
        public ToDo_DB_Models.ToDo todo { get; set; }

        public ICollection<ToDo_DB_Models.ToDo> CompleteTodos { get; set; }
        public ICollection<ToDo_DB_Models.ToDo> IncompleteTodos { get; set; }



        public IndexModel(ILogger<IndexModel> logger, ToDoContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet([FromQuery] int Id = 0)
        {
            if (Id == 0)
            {
                //ViewData["todo"] = _db.ToDos;
                var incompleteTodos = _db.ToDos.Select(todo => todo).Where(todo => todo.Status == "incomplete");
                IncompleteTodos = incompleteTodos.ToList();
                var completeTodos = _db.ToDos.Select(todo => todo).Where(todo => todo.Status == "complete");
                CompleteTodos = completeTodos.ToList();
            }
            else
            {
                todo = _db.ToDos.Where(todo => todo.Id == Id).FirstOrDefault();
            }
        }

        public void OnPost()
        {
            _db.ToDos.Update(todo);
            _db.SaveChangesAsync();
            var incompleteTodos = _db.ToDos.Select(todo => todo).Where(todo => todo.Status == "incomplete");
            IncompleteTodos = incompleteTodos.ToList();
            var completeTodos = _db.ToDos.Select(todo => todo).Where(todo => todo.Status == "complete");
            CompleteTodos = completeTodos.ToList();
        }
    }
}
