using System;
using Xunit.Abstractions;

namespace LinearList.Tests
{
    public class BaseTests
    {
        private readonly ITestOutputHelper _output;

        protected BaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        protected void PrintLinkedList<T>(SingleLinkedList<T> list) where T : IComparable<T>
        {
            if (list == null) return;

            var p = list.First;
            while (p != null)
            {
                _output.WriteLine(p.Value?.ToString());
                p = p.Next;
            }
        }

        protected void PrintSqList<T>(SqList<T> list) where T : IComparable<T>
        {
            if (list == null) return;

            for (int idx = 0; idx < list.Length; idx++)
            {
                _output.WriteLine(list.Find(idx).ToString());
            }
        }

        protected void PrintStackArray<T>(ArrayStack<T> list)
        {
            if (list.Count == 0) return;

            while (list.Count > 0)
            {
                T item = list.Pop();
                _output.WriteLine(item.ToString());
            }
        }

        protected void PrintStackLinkedList<T>(LinkedStack<T> list)
        {
            if (list.Count == 0) return;

            while (list.Count>0)
            {
                var val = list.Pop();
                _output.WriteLine(val.ToString());
            }
        }
    }
}