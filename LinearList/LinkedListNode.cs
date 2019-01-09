using System;
using System.Collections.Generic;

namespace LinearList
{
    public class LinkedListNode<T>
    {
        private T _value;

        public LinkedListNode(T value)
        {
            _value = value;
        }

        public T Value => _value;
        public LinkedListNode<T> Next { get; set; }
    }
}