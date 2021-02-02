using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.data;
using TodoList.Models;
using TodoList.Services.Interface;

namespace TodoList.Services.Repository
{
    public class TasksRepository : ITasks
    {
        private Appdbcontext _dbcontext;

        public TasksRepository(Appdbcontext dbcontext)
        {

            _dbcontext = dbcontext;

        }

        public IEnumerable<Tasks> GetAllTask()
        {
           var allTask =  _dbcontext.Tasks;
            return allTask;
        }

        public List<Tasks> GetTaskWithSatusCart()
        {

            var fullTask = _dbcontext.Tasks.Include(x=>x.Cartegory).Include(c=>c.Status).ToList();

            return fullTask;
        }

        public void ChangeStatus(int id)
        {

            var task = _dbcontext.Tasks.Where(x => x.Id == id).ToList().FirstOrDefault();

            var stat = task.StatusId == 1 ? 2 : 1;

            task.StatusId = stat;

            _dbcontext.SaveChanges();


        }


        public void DeleteTasks(int id)
        {

          var task =  _dbcontext.Tasks.Find(id);

            _dbcontext.Tasks.Remove(task);
            _dbcontext.SaveChanges();
         
         
        }

        public IEnumerable<Tasks> SortTask(int status, int cart, DateTime date)
        {



            var allSortTask = _dbcontext.Tasks.Where(x => x.StatusId == status && x.CartegoryId == cart || x.DueDate.Year == date.Year && x.DueDate.Month == date.Month).Include(x => x.Cartegory).Include(c => c.Status).ToList();
            return allSortTask;
        }

    }
}
