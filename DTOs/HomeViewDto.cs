using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.DTOs
{
    public class HomeViewDto
    {

        public   IEnumerable<Tasks> AllTask { get; set; }
        public ReturnTaskDto TodoTask { get; set; }
        public int Taskcount { get; set; }

        public FilterDto Filter { get; set; }
    }
}
