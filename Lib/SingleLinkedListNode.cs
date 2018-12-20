using System;

namespace Lib
{
    // Node of single linked list
    public class SingleLinkedListNode<T>
    {
        private T _node;

        public SingleLinkedListNode(T node)
        {
            _node = node;
        }

        public SingleLinkedListNode<T> Next { get; set; }

        public T Value => _node;
    }
}