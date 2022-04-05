using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo_DB_Context;
using ToDo_DB_Models;

namespace ToDo.Pages
{
    public class AddTodoModel : PageModel
    {
        private readonly ToDoContext _db;

        [FromForm]
        public ToDo_DB_Models.ToDo todo { get; set; }

        public AddTodoModel(ToDoContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async void OnPost()
        {
            _db.Add<ToDo_DB_Models.ToDo>(todo);
            await _db.SaveChangesAsync();
        }
    }
}