using System;
using Microsoft.EntityFrameworkCore;
using ToDo_DB_Models;

namespace ToDo_DB_Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

    }
}