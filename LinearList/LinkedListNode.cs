using System;

namespace LinearList
{
    public class LinkedListNode<T> where T : IEquatable<T>
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