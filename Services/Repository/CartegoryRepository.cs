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
    public class CartegoryRepository :ICartegory
    {
        private Appdbcontext _dbcontext;

        public CartegoryRepository(Appdbcontext dbContext)
        {
            _dbcontext = dbContext;
        }


        public IEnumerable<Cartegory> GetAllCartegory()
        {

         var allCartegories =  _dbcontext.Cartegories;

            return allCartegories;

        }

        public void SaveCartegory(Tasks task)
        {
            _dbcontext.Tasks.Add(task);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Status> GetAllStatus()
        {
          return  _dbcontext.Status;
        }
    }
}
