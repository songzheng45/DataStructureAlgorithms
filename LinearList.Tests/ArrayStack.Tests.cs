using System;
using Xunit;
using Xunit.Abstractions;

namespace LinearList.Tests
{
    public class ArrayStackTests : BaseTests
    {
        public ArrayStackTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Push_3_Elements_Then_Length_Equal_3()
        {
            var stack = new ArrayStack<int>(5);
            stack.Push(2);
            stack.Push(4);
            stack.Push(6);

            Assert.Equal(3, stack.Count);

            PrintStackArray(stack);
        }

        [Fact]
        public void Push_Throw_InvalidOperationException_When_Stack_Full()
        {
            var stack = new ArrayStack<int>(5);
            stack.Push(2);
            stack.Push(4);
            stack.Push(6);
            stack.Push(8);
            stack.Push(10);

            Exception ex = Assert.Throws<InvalidOperationException>(() => stack.Push(11));
            Assert.IsType<InvalidOperationException>(ex);

            PrintStackArray(stack);
        }

        [Fact]
        public void Pop_Throw_InvalidOperationException_When_Stack_Empty()
        {
            var stack = new ArrayStack<int>(5);

            Exception ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.IsType<InvalidOperationException>(ex);

            PrintStackArray(stack);
        }

        [Fact]
        public void Pop_Valid_When_Stack_Not_Empty()
        {
            var stack = new ArrayStack<int>(5);
            stack.Push(2);
            stack.Push(4);

            int val = stack.Pop();
            Assert.Equal(4, val);

            PrintStackArray(stack);
        }
    }
}