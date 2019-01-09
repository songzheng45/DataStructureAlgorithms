using System;

namespace LinearList
{
    /// <summary>
    /// 单链表的插入、删除、清空、查找
    /// 1. 链表反转
    /// 2. 环的检测
    /// 3. 两个有序链表的合并
    /// 4. 删除链表倒数第n个结点
    /// 5. 求链表的中间结点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        private readonly LinkedListNode<T> _head;

        public SingleLinkedList()
        {
            _head = new LinkedListNode<T>(default(T));
        }

        public SingleLinkedList(params T[] list)
        {
            _head = new LinkedListNode<T>(default(T));
            if (list == null) return;

            var p = _head;
            foreach (var item in list)
            {
                var q = new LinkedListNode<T>(item);
                p.Next = q;
                p = q;
            }
        }

        // Head node
        public LinkedListNode<T> First => _head.Next;
        public LinkedListNode<T> Head => _head;

        public int Length { get; private set; }

        public LinkedListNode<T> Insert(int position, T newElem)
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

            return newNode;
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
        /// <remarks>
        /// 用快慢两个指针，快指针每次移动2个结点，慢指针每次移动1个结点，当两个指针相遇时，说明存在环。
        /// LeetCode 编号： 141
        /// </remarks>
        public bool HasCycle()
        {
            if (Length == 0) return false;

            var slow = _head.Next;
            var fast = _head.Next.Next;

            while (fast != null && slow != null && fast != slow)
            {
                fast = fast.Next?.Next;
                slow = slow.Next;
            }

            bool ret = fast == slow;
            return ret;
        }

        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        /// <remarks>LeetCode 编号： 21</remarks>
        /// <param name="list"></param>
        /// <returns></returns>
        public SingleLinkedList<T> Merge(SingleLinkedList<T> list)
        {
            if (list == null) return this;

            var root = new SingleLinkedList<T>();

            LinkedListNode<T> pointer = root._head;

            var head1 = list.First;
            var head2 = this.First;
            while (head1 != null && head2 != null)
            {
                if (head1.Value.CompareTo(head2.Value) < 0)
                {
                    pointer.Next = head1;
                    head1 = head1.Next;
                }
                else
                {
                    pointer.Next = head2;
                    head2 = head2.Next;
                }

                pointer = pointer.Next;
            }

            if (head1 != null)
            {
                pointer.Next = head1;
            }

            if (head2 != null)
            {
                pointer.Next = head2;
            }

            return root;
        }
    }
}