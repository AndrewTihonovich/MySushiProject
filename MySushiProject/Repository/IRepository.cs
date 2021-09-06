using System;
using System.Collections.Generic;

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
