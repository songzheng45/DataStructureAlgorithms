using System;
using Xunit;
using Xunit.Abstractions;

namespace LinearList.Tests
{
    /// <summary>
    /// Single Linked List Unit Tests
    /// </summary>
    public class SingleLinkedListTests
    {
        private readonly SingleLinkedList<string> _defaultLinkList;
        private readonly ITestOutputHelper _output;

        public SingleLinkedListTests(ITestOutputHelper output)
        {
            _defaultLinkList = new SingleLinkedList<string>();
            _output = output;
        }

        private void PrintList<T>(SingleLinkedList<T> list) where T : IComparable<T>
        {
            if (list == null) return;

            var p = list.First;
            while (p != null)
            {
                _output.WriteLine(p.Value + " ");
                p = p.Next;
            }
        }

        [Fact]
        public void Insert_3_Elements_Return_Length_3()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            PrintList(_defaultLinkList);

            Assert.Equal(3, _defaultLinkList.Length);
        }

        [Fact]
        public void Insert_Some_Elements_Then_Verify_First()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            Assert.Equal("The", _defaultLinkList.First.Value);
        }

        [Fact]
        public void Insert_Some_Elements_Then_Verify_Last()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            Assert.Equal("Brown", _defaultLinkList.First.Next.Next.Value);
        }

        [Fact]
        public void Find_Return_Null_When_Postion_LessThan_1()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            var node = _defaultLinkList.Find(0);
            Assert.Null(node);
        }

        [Fact]
        public void Find_Return_Null_When_Postion_GreaterThan_Length()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            var node = _defaultLinkList.Find(4);
            Assert.Null(node);
        }

        [Fact]
        public void Find_Return_Correct_When_Postion_Valid()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            var node = _defaultLinkList.Find(2);
            Assert.Equal("Quick", node.Value);
        }

        [Fact]
        public void Delete_Return_Null_When_Postion_LessThan_1()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            var node = _defaultLinkList.Delete(0);
            Assert.Null(node);
        }

        [Fact]
        public void Delete_Return_Null_When_Postion_GreaterThan_Length()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            var node = _defaultLinkList.Delete(4);
            Assert.Null(node);
        }

        [Fact]
        public void Delete_Success_When_Position_Valid()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");
            _defaultLinkList.Insert(4, "fox");
            _defaultLinkList.Insert(5, "jumps");
            _defaultLinkList.Insert(6, "over");
            _defaultLinkList.Insert(7, "the");
            _defaultLinkList.Insert(8, "lazy");
            _defaultLinkList.Insert(9, "dog");

            var node = _defaultLinkList.Delete(3);

            PrintList(_defaultLinkList);

            Assert.Equal("Brown", node.Value);
            Assert.Equal(8, _defaultLinkList.Length);
        }

        [Fact]
        public void Clear_Length_Equal_0()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            _defaultLinkList.Clear();

            Assert.Equal(0, _defaultLinkList.Length);
        }

        [Fact]
        public void Clear_First_Is_Null()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");

            _defaultLinkList.Clear();

            Assert.Null(_defaultLinkList.First);
        }

        [Fact]
        public void Reverse_When_List_Is_Empty()
        {
            _defaultLinkList.Reverse();

            PrintList(_defaultLinkList);

            Assert.Null(_defaultLinkList.First);
        }

        [Fact]
        public void Reverse_When_List_Has_Many_Elements()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");
            _defaultLinkList.Insert(4, "fox");
            _defaultLinkList.Insert(5, "jumps");
            _defaultLinkList.Insert(6, "over");
            _defaultLinkList.Insert(7, "the");
            _defaultLinkList.Insert(8, "lazy");
            _defaultLinkList.Insert(9, "dog");

            _defaultLinkList.Reverse();

            PrintList(_defaultLinkList);

            Assert.True(_defaultLinkList.First.Value == "dog");
        }

        [Fact]
        public void HasCycle_List_Empty()
        {
            bool hasCycle = _defaultLinkList.HasCycle();

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycle_False_When_List_Length_1()
        {
            _defaultLinkList.Insert(1, "The");

            bool hasCycle = _defaultLinkList.HasCycle();

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycle_False_When_List_Length_2()
        {
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");

            bool hasCycle = _defaultLinkList.HasCycle();

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycle_True_When_List_Length_2()
        {
            var firstNode = _defaultLinkList.Insert(1, "The");
            var secondNode = _defaultLinkList.Insert(2, "Quick");

            secondNode.Next = firstNode;

            bool hasCycle = _defaultLinkList.HasCycle();

            Assert.True(hasCycle);
        }

        [Fact]
        public void HasCycle_False()
        {
            var linkList =
                new SingleLinkedList<string>("The", "Quick", "Brown", "fox", "jumps", "over", "the", "lazy", "dog");

            bool hasCycle = linkList.HasCycle();

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycle_True()
        {
            // 初始化一个具有环的链表
            _defaultLinkList.Insert(1, "The");
            _defaultLinkList.Insert(2, "Quick");
            _defaultLinkList.Insert(3, "Brown");
            var fourthNode = _defaultLinkList.Insert(4, "fox");
            _defaultLinkList.Insert(5, "jumps");
            _defaultLinkList.Insert(6, "over");
            _defaultLinkList.Insert(7, "the");
            _defaultLinkList.Insert(8, "lazy");
            var last = _defaultLinkList.Insert(9, "dog");

            last.Next = fourthNode;

            bool hasCycle = _defaultLinkList.HasCycle();

            Assert.True(hasCycle);
        }

        [Fact]
        public void Merge_Success()
        {
            var list1 = new SingleLinkedList<int>(1, 2, 4);
            var list2 = new SingleLinkedList<int>(1, 3, 4);

            var list3 = list1.Merge(list2);

            PrintList(list3);

            Assert.True(list1.First.Next.Next.Value == 2);
        }
    }
}