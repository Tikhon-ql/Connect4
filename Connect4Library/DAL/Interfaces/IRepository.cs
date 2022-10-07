using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T data);
        T Read(string id);
        void Update(T data);
        void Delete(T data);
        void Delete(string id);
        IEnumerable<T> ReadAll();
    }
}
