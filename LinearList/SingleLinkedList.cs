using System;

namespace LinearList
{
    // single linked list
    public class SingleLinkedList<T> where T : IEquatable<T>
    {
        private readonly LinkedListNode<T> _head;

        public SingleLinkedList()
        {
            _head = new LinkedListNode<T>(default(T));
        }

        // Head node
        public LinkedListNode<T> First => _head.Next;

        public int Length { get; private set; }

        public void Insert(int position, T newElem)
        {
            if (position < 1 || position > Length + 1)
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

            Length++;
        }

        public LinkedListNode<T> Find(int position)
        {
            LinkedListNode<T> p = First;
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
            if (position < 1 || position > Length)
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

            Length--;

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

            Length = 0;
        }

        /// <summary>
        /// reverse current list
        /// </summary>
        public void Reverse()
        {
            if (Length <= 1) return;

            LinkedListNode<T> p = First;
            LinkedListNode<T> q = First.Next;

            LinkedListNode<T> r = null;

            p.Next = null;
            while (q != null)
            {
                r = q.Next;

                q.Next = p;
                p = q;
                q = r;
            }

            _head.Next = p;
        }

        /// <summary>
        /// 环的检测
        /// </summary>
        public void IsCircular()
        {
        }
    }
}