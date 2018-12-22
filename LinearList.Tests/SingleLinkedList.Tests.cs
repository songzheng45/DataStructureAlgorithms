using System;
using Xunit;

namespace LinearList.Tests
{
    public class SingleLinkedList_Tests
    {
        private SingleLinkedList<string> _linkList;

        public SingleLinkedList_Tests()
        {
            _linkList = new SingleLinkedList<string>();
        }

        [Fact]
        public void Insert_3_Elements_Return_Length_3()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            Assert.Equal(3, _linkList.Length);
        }

        [Fact]
        public void Insert_Some_Elements_Then_Verify_First()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            Assert.Equal("The", _linkList.First.Value);
        }

        [Fact]
        public void Insert_Some_Elements_Then_Verify_Last()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            Assert.Equal("Brown", _linkList.First.Next.Next.Value);
        }

        [Fact]
        public void Find_Return_Null_When_Postion_LessThan_1()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Find(0);
            Assert.Null(node);
        }

        [Fact]
        public void Find_Return_Null_When_Postion_GreaterThan_Length()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Find(4);
            Assert.Null(node);
        }

        [Fact]
        public void Find_Return_Correct_When_Postion_Valid()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Find(2);
            Assert.Equal("Quick", node.Value);
        }

        [Fact]
        public void Delete_Return_Null_When_Postion_LessThan_1()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Delete(0);
            Assert.Null(node);
        }

        [Fact]
        public void Delete_Return_Null_When_Postion_GreaterThan_Length()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Delete(4);
            Assert.Null(node);
        }

        [Fact]
        public void Delete_Success_When_Position_Valid()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            var node = _linkList.Delete(2);
            Assert.Equal("Brown", _linkList.First.Next.Value);
            Assert.Equal(2, _linkList.Length);
        }

        [Fact]
        public void Clear_Length_Equal_0()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            _linkList.Clear();

            Assert.Equal(0, _linkList.Length);
        }

        [Fact]
        public void Clear_First_Is_Null()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            _linkList.Clear();

            Assert.Null(_linkList.First);
        }
    }
}