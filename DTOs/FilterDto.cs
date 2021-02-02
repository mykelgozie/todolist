using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.DTOs
{
    public class FilterDto
    {

        public int Cartegory { get; set; }

        public int Status { get; set; }

        public DateTime Date { get; set; }
    }
}
