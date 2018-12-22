using System;

namespace LinearList
{
    // single linked list
    public class SingleLinkedList<T> where T : IEquatable<T>
    {
        private int _length;
        private LinkedListNode<T> _head;

        public SingleLinkedList()
        {
            _head = new LinkedListNode<T>(default(T));
        }

        // Head node
        public LinkedListNode<T> First => _head.Next;
        public LinkedListNode<T> Last { get; set; }

        public int Length => _length;

        public void Insert(int position, T newElem)
        {
            if (position < 1 || position > _length + 1)
            {
                throw new IndexOutOfRangeException("Position must be in bound of list");
            }

            var p = _head;

            int j = 1;
            while (p != null && j < position)
            {
                p = p.Next;
                ++j;
            }

            var newNode = new LinkedListNode<T>(newElem);
            newNode.Next = p.Next;
            p.Next = newNode;

            _length++;
        }

        public LinkedListNode<T> Find(int position)
        {
            LinkedListNode<T> p = _head.Next;
            int j = 1;

            while (p != null && j < position)
            {
                p = p.Next;
                j++;
            }

            if (p == null || j > position)
            {
                return null;
            }

            return p;
        }

        public LinkedListNode<T> Find(T elem)
        {
            LinkedListNode<T> p = _head.Next;

            while (p != null)
            {
                if (p.Value.Equals(elem)) return p;

                p = p.Next;
            }

            return null;
        }

        public LinkedListNode<T> Delete(int position)
        {
            if (position < 1 || position > _length)
            {
                return null;
            }

            var p = _head.Next;
            int j = 1;
            while (p != null && j < position - 1)
            {
                p = p.Next;
                ++j;
            }

            var q = p.Next;
            p.Next = q.Next;

            _length--;

            return q;
        }

        public void Clear()
        {
            var cur = _head;
            while (cur.Next != null)
            {
                var q = cur.Next;
                cur.Next = null;

                cur = q;
            }
            _length = 0;
        }


    }
}
