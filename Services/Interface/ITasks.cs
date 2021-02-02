using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.Interface
{
    public interface ITasks
    {

        public IEnumerable<Tasks> GetAllTask();

        public List<Tasks> GetTaskWithSatusCart();

        public void ChangeStatus(int id);

        public void DeleteTasks(int id);

        public IEnumerable<Tasks> SortTask(int status, int cart, DateTime date);
    }
}
