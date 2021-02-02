using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class Tasks
    {
        [Key]
        public int Id  { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public  Status  Status { get; set; }
        public int CartegoryId { get; set; }
        public Cartegory Cartegory { get; set; }
    }

   
}
