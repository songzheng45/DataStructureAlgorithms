using System;
using System.Diagnostics;
using System.Text;

namespace LinearList
{
    public class SequenceList<T> : BaseList<T> where T : IEquatable<T>
    {
        private T[] _data;
        private int _capacity;
        private int _length;

        public SequenceList(int capacity)
        {
            _data = new T[capacity];
            _capacity = capacity;
            _length = 0;
        }

        // length of list
        public override int Length => _length;

        // clear list
        public override void Clear()
        {
            _data = new T[_capacity];
            _length = 0;
        }

        // get an element base on index
        public override T Find(int position)
        {
            if (position < 0 || position > _length)
            {
                throw new IndexOutOfRangeException("Position was outside the bounds of the list");
            }
            return _data[position - 1];
        }

        // search the element which matches specified element and return its index
        public override int IndexOf(T elem)
        {
            if (_length == 0) return -1;
            if (_data[0].Equals(elem)) return 0;
            if (_data[_length - 1].Equals(elem)) return _length - 1;

            int start = 0;
            while (start < _length - 1)
            {
                if (_data[start].Equals(elem)) return start;
                start++;
                continue;
            }

            return -1;
        }

        // insert a new element at specified index
        public override void Insert(int position, T newElem)
        {
            Console.WriteLine("Insert position is " + position);

            if (_length == _capacity)
            {
                throw new OutOfMemoryException("List has now more space");
            }

            if (position < 1 || position > _length + 1)
            {
                throw new IndexOutOfRangeException("Position was outside the bounds of the list");
            }

            // to loop array from last position until finding the target position
            if (position <= _length)
            {
                for (int k = _length - 1; k >= position - 1; k--)
                {
                    _data[k + 1] = _data[k];

                }
            }
            _data[position - 1] = newElem;

            _length++;
        }

        // delete an element base on its index
        public override T Delete(int position)
        {
            if (position < 1 || position > _length)
            {
                throw new IndexOutOfRangeException("Position must be in the bound of list");
            }

            var elem = _data[position - 1];
            for (int k = position; k < _length; k++)
            {
                _data[k - 1] = _data[k];
            }

            _length--;

            return elem;
        }

        public override string ToString()
        {
            if (_length == 0) return string.Empty;

            var builder = new StringBuilder();
            for (int idx = 0; idx < _length; idx++)
            {
                T item = _data[idx];
                builder.Append($"{item.ToString()}");
                if (idx < _length - 1) builder.Append(",");
            }

            return builder.ToString();
        }
    }
}
