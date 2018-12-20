using System;
using System.Diagnostics;
using System.Text;

namespace P01_LinearList
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
        }

        // get an element base on index
        public override T GetElem(int index)
        {
            if (index < 0 || index >= _length) return default(T);
            return _data[index];
        }

        // search the element which matches specified element and return its index
        public override int LocateElem(T elem)
        {
            if (_length == 0) return -1;
            if (_data[0].Equals(elem)) return 0;
            if (_data[_length - 1].Equals(elem)) return _length - 1;

            int start = 0;
            while (start < _length - 1)
            {
                if (_data[start].Equals(elem)) return start;
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
            int k;
            for (k = _length - 1; k >= position - 1; k--)
            {
                _data[k + 1] = _data[k];

            }
            _data[k] = newElem;

            _length++;
        }

        // delete an element base on its index
        public override T Delete(int position)
        {
            if (position < 0)
            {
                throw new IndexOutOfRangeException("Index must be a positive integer");
            }

            if (position >= _length)
            {
                throw new IndexOutOfRangeException("Index must be valid");
            }

            var elem = _data[position];
            for (int start = position; start < _length - 1; start++)
            {
                _data[start] = _data[start + 1];
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
