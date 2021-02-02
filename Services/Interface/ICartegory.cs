using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.Interface
{
    public interface ICartegory
    {

        public IEnumerable<Cartegory> GetAllCartegory();

        public void SaveCartegory(Tasks task);

        public IEnumerable<Status> GetAllStatus();
    }
}
