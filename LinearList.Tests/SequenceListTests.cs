using System;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using LinearList;

namespace LinearList_Tests
{
    public class SequenceListTests
    {
        private readonly SequenceList<int> _sqlist;
        private readonly ITestOutputHelper _output;

        public SequenceListTests(ITestOutputHelper output)
        {
            _sqlist = new SequenceList<int>(10);
            _output = output;
        }

        [Fact]
        public void Length_Equal_0_When_ListEmpty()
        {
            Assert.True(_sqlist.Length == 0);
        }

        [Fact]
        public void Length_Equal_1_After_InsertOneElement()
        {
            _sqlist.Insert(1, 1);
            Assert.True(_sqlist.Length == 1);
        }

        [Fact]
        public void Insert_ThrowIndexOutOfRangeException_When_PostionGreaterThanLength()
        {
            _sqlist.Insert(1, 1);
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Insert(3, 1));
            Assert.Equal("Position was outside the bounds of the list", ex.Message);
        }

        [Fact]
        public void Insert_ThrowIndexOutOfRangeException_When_PostionLessThanOne()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Insert(0, 1));
            Assert.Equal("Position was outside the bounds of the list", ex.Message);
        }

        [Fact]
        public void Insert_ThrowIndexOutOfRangeException_When_List_Is_Full()
        {
            _sqlist.Insert(1, 10);
            _sqlist.Insert(2, 9);
            _sqlist.Insert(3, 8);
            _sqlist.Insert(4, 7);
            _sqlist.Insert(5, 6);
            _sqlist.Insert(6, 5);
            _sqlist.Insert(7, 4);
            _sqlist.Insert(8, 3);
            _sqlist.Insert(9, 2);
            _sqlist.Insert(10, 1);

            Exception ex = Assert.Throws<OutOfMemoryException>(() => _sqlist.Insert(11, 101));
            Assert.IsType<OutOfMemoryException>(ex);
        }

        [Fact]
        public void Delete_ThrowIndexOutOfRangeException_When_PositionLessThanOne()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Delete(0));
            Assert.Equal("Position must be in the bound of list", ex.Message);
        }

        [Fact]
        public void Delete_ThrowIndexOutOfRangeException_When_PositionGreaterThanLength()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Delete(3));
            Assert.Equal("Position must be in the bound of list", ex.Message);
        }

        [Fact]
        public void Delete_First_Element()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);

            var elem = _sqlist.Delete(1);
            Assert.Equal(11, elem);
        }

        [Fact]
        public void Delete_Last_Element()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            var elem = _sqlist.Delete(3);
            Assert.Equal(33, elem);
        }

        [Fact]
        public void Delete_Middle_Element()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            var elem = _sqlist.Delete(2);
            Assert.Equal(22, elem);
        }

        [Fact]
        public void GetElem_ThrowsIndexOutOfRangeException_When_PostionLessThanZero()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Find(0));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void GetElem_ThrowsIndexOutOfRangeException_When_PostionGreaterThanLength()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Find(4));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void GetElem_Last_Position_Return_33()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);


            var elem = _sqlist.Find(3);

            Assert.Equal(33, elem);
        }

        [Fact]
        public void GetElem_First_Position_Return_11()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);


            var elem = _sqlist.Find(1);

            Assert.Equal(11, elem);
        }

        [Fact]
        public void IndexOf_Return_Netagive1_When_Element_Not_Exist()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            var elem = _sqlist.IndexOf(55);

            Assert.Equal(-1, elem);
        }

        [Fact]
        public void IndexOf_Return_First_Index()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            var elem = _sqlist.IndexOf(11);

            Assert.Equal(0, elem);
        }

        [Fact]
        public void IndexOf_Return_Last_Index()
        {
            _sqlist.Insert(1, 11);
            _sqlist.Insert(2, 22);
            _sqlist.Insert(3, 33);

            var elem = _sqlist.IndexOf(33);

            Assert.Equal(2, elem);
        }

        [Fact]
        public void Clear_Length_Equal_Zero_If_Empty()
        {
            _sqlist.Insert(1, 10);
            _sqlist.Insert(2, 9);
            _sqlist.Insert(3, 8);
            _sqlist.Insert(4, 7);
            _sqlist.Insert(5, 6);
            _sqlist.Insert(6, 5);
            _sqlist.Insert(7, 4);
            _sqlist.Insert(8, 3);
            _sqlist.Insert(9, 2);
            _sqlist.Insert(10, 1);

            Assert.Equal(10, _sqlist.Length);

            _sqlist.Clear();

            Assert.Equal(0, _sqlist.Length);
        }
    }
}
