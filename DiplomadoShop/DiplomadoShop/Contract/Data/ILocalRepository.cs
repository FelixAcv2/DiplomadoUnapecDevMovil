using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Contract.Data
{
  public  interface ILocalRepository<T>:IDisposable where T:class
    {
        int Insert(T entity);
        IEnumerable<T> GetAll();
      
    }
}
