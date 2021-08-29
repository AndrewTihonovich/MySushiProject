using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Repository
{
    interface IRepository<T>
    {
        public void Add(T item);
        public List<T> GetAll();
        public T GetById(Guid id);
        public void Delete(Guid id);//
        public void Update(T item);//
    }
}
