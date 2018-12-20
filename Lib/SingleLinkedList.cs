using System;

namespace Lib
{
    // An implementation of single linked list  
    public class SingleLinkedList<T>
    {
        private int _length;
        private SingleLinkedListNode<T> _first;
        private SingleLinkedListNode<T> _last;

        #region Constructors

        public SingleLinkedList(T[] array)
        {
        }

        #endregion

        #region Properties

        public int Count => _length;

        public SingleLinkedListNode<T> First => _first;
        public SingleLinkedListNode<T> Last => _last;

        #endregion

        #region Insert

        // Insert an element into last position of unsorted list
        public void Insert(T elem)
        {
            var newNode = new SingleLinkedListNode<T>(elem);

            if (_length == 0)
            {
                _first = _last = newNode;
            }
            else
            {
                _last.Next = newNode;
            }

            _length++;
        }

        public void Insert(int index, T elem)
        {
            if (index < 0 || index > _length - 1)
            {
                throw new IndexOutOfRangeException("Index must be within the bounds of the List. ");
            }
        }

        #endregion

        #region Delete

        // Delete element which is at specified index
        public void Delete(int index, T elem)
        {
            if (index < 0 || index > _length - 1)
            {
                throw new IndexOutOfRangeException("Index must be within the bounds of the List. ");
            }
        }

        // Delete an element
        public void Delete(T elem)
        {

        }

        #endregion

        #region Find
        public SingleLinkedListNode<T> Find(T elem)
        {
            if (_length == 0) return null;
            if (_first == _last && object.Equals(_first.Value, elem))
            {
                return _first;
            }
            else
            {
                return null;
            }

        }

        #endregion
    }
}
