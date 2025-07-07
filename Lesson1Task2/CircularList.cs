using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Lesson1Task2
{
    internal class Node<T>
    {
        internal T Value { get; set; }
        internal Node<T> NextItem { get; set; }
        internal Node(T value, Node<T> nextItem)
        {
            Value = value;
            NextItem = nextItem;
        }

    }
    public class CircularList<T> : IEnumerable<T>
    {
        internal Node<T> item1;
        private Node<T> item2;
        private Node<T> item3;
        public CircularList() { }
        public CircularList(T value1, T value2, T value3)
        {
            this.item1 = new Node<T>(value1, null);
            this.item2 = new Node<T>(value2, null);
            this.item3 = new Node<T>(value3, null);
            item1.NextItem = item2;
            item2.NextItem = item3;
            item3.NextItem = item1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ColorListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class ColorListEnumerator<T> : IEnumerator<T>
    {
        CircularList<T> list;
        Node<T> item;
        internal ColorListEnumerator(CircularList<T> list)
        {
            this.list = list;
            item = null;
        }
        public T Current => item.Value;
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            if (item == null)
                item = list.item1;
            else
                item = item.NextItem;
            return true;
        }
        public void Dispose() { }
        public void Reset() { }
    }
}
