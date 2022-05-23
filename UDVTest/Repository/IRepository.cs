using System.Collections.Generic;

namespace UDVTest.Repository
{
    public interface IRepository<T> where T:class
    {
        T Get(string name);
        void Delete(string name);
        void Add(string name);
        List<string> GetNames();
    }
}