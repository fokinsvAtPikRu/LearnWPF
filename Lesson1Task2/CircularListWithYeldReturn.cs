using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1Task2
{
    internal class CircularListWithYeldReturn<T> : IEnumerable<T>
    {
        T item1;
        T item2;
        T item3;
        internal CircularListWithYeldReturn() { }
        internal CircularListWithYeldReturn(T item1, T item2, T item3) 
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;        
        }

        public IEnumerator<T> GetEnumerator()
        {
            while(true)
            {
                yield return item1;
                yield return item2;
                yield return item3;    
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
