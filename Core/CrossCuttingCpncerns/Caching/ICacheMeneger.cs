using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingCpncerns.Caching
{
    public interface ICacheMeneger
    {
        void Add(string key, object value, int duration);

        T Get<T>(string key);
        object Get(string key); //generik olmayan

        bool IsAdd(string key); //cache te var mı

        void Remove(string key); // cachten sil

        void RemoveByPattern(string pattern);

    }
}
