using System;
using Xunit;
using Xunit.Abstractions;

namespace LinearList.Tests
{
    public class LinkedStackTests : BaseTests
    {
        public LinkedStackTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Push_3_Elements_Then_Length_Equal_3()
        {
            var stack = new LinkedStack<int>();
            stack.Push(2);
            stack.Push(4);
            stack.Push(6);

            Assert.Equal(3, stack.Count);

            PrintStackLinkedList(stack);
        }

        [Fact]
        public void Pop_Throw_InvalidOperationException_When_Stack_Empty()
        {
            var stack = new LinkedStack<int>();

            Exception ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.IsType<InvalidOperationException>(ex);

            PrintStackLinkedList(stack);
        }

        [Fact]
        public void Pop_Valid_When_Stack_Not_Empty()
        {
            var stack = new LinkedStack<int>();
            stack.Push(2);
            stack.Push(4);

            var nodeVal = stack.Pop();
            Assert.Equal(4, nodeVal);

            PrintStackLinkedList(stack);
        }
    }
}
