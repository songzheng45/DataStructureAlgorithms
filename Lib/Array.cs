using System;

namespace Lib
{
    public class Array<T>
    {
        private int _size;
        private T[] _array;

        public Array(int capacity)
        {
            _array = new T[capacity];
        }

        public int Size => _size;

        #region Public Methods

        public T Find(int index)
        {
            IsIndexValid(index);

            return _array[index];
        }

        public int Find(T elem)
        {
            if (_size <= 0) return -1;
            if (_array[_size - 1] == elem) return _size - 1;

            for (int idx = 0; idx < _array.Length; idx++)
            {
                if (_array[idx] == elem) return idx;
            }

            return -1;
        }

        public void Insert(T elem)
        {
            if (_size < _array.Length)
            {
                _size++;
                _array[_size - 1] = elem;
            }
            else
            {
                // No additional space
                // throw new OutOfMemoryException("");
            }
        }

        #endregion

        #region Private Methods

        private void IsIndexValid(int index)
        {
            if (index < 0 || index > _array.Length - 1)
            {
                throw new IndexOutOfRangException("Index must be in range of Array");
            }
        }

        #endregion
    }
}