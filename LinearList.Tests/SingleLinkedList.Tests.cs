using Xunit;
using Xunit.Abstractions;

namespace LinearList.Tests
{
    /// <summary>
    /// Single Linked List Unit Tests
    /// </summary>
    public class SingleLinkedListTests
    {
        private readonly SingleLinkedList<string> _linkList;
        private readonly ITestOutputHelper _output;

        public SingleLinkedListTests(ITestOutputHelper output)
        {
            _linkList = new SingleLinkedList<string>();
            _output = output;
        }

        private void PrintList()
        {
            var p = _linkList.First;
            while (p != null)
            {
                _output.WriteLine(p.Value + " ");
                p = p.Next;
            }
        }

        [Fact]
        public void Insert_3_Elements_Return_Length_3()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");

            PrintList();

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
            _linkList.Insert(4, "fox");
            _linkList.Insert(5, "jumps");
            _linkList.Insert(6, "over");
            _linkList.Insert(7, "the");
            _linkList.Insert(8, "lazy");
            _linkList.Insert(9, "dog");

            var node = _linkList.Delete(3);

            PrintList();

            Assert.Equal("Brown", node.Value);
            Assert.Equal(8, _linkList.Length);
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

        [Fact]
        public void Reverse_When_List_Is_Empty()
        {
            _linkList.Reverse();

            PrintList();

            Assert.Null(_linkList.First);
        }

        [Fact]
        public void Reverse_When_List_Has_Many_Elements()
        {
            _linkList.Insert(1, "The");
            _linkList.Insert(2, "Quick");
            _linkList.Insert(3, "Brown");
            _linkList.Insert(4, "fox");
            _linkList.Insert(5, "jumps");
            _linkList.Insert(6, "over");
            _linkList.Insert(7, "the");
            _linkList.Insert(8, "lazy");
            _linkList.Insert(9, "dog");

            _linkList.Reverse();

            PrintList();

            Assert.True(_linkList.First.Value == "dog");
        }
    }
}