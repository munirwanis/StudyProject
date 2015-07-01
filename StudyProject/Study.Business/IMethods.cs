using System.Collections;
using System.Collections.Generic;

namespace Study.Business
{
    public interface IMethods<T, Q>
    {
        void Create(Q someDto);

        void Update(int someId, Q someDto);
        
        void Delete(int someId);

        List<T> Display();

        T Find(int someId);
    }
}