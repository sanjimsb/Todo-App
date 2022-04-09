using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ToDo_DB_Models
{
    public class ToDo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string TodoName { get; set; }

        [Required]
        public string TodoDescription { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
