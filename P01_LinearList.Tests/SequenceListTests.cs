using System;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using P01_LinearList;

namespace SequenceListTests
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
        public void Insert_ThrowIndexOutOfRangeException_When_PostionGreaterThanListLength()
        {
            _sqlist.Insert(1, 1);
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Insert(3, 1));
            Assert.Equal("Position was outside the bounds of the list", ex.Message);
        }

        [Fact]
        public void Insert_ThrowIndexOutOfRangeException_When_PostionLessThan_1()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => _sqlist.Insert(0, 1));
            Assert.Equal("Position was outside the bounds of the list", ex.Message);
        }

        [Fact]
        public void Insert_Some_Elements_Return_All()
        {
            _sqlist.Insert(1, 10);
            _sqlist.Insert(2, 9);
            _sqlist.Insert(3, 8);

            Assert.Equal("10,9,8", _sqlist.ToString());
        }
    }
}
