using System;
using Xunit;

namespace RingCentral.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var obj1 = new Class1();
            Assert.Equal(3, obj1.sum(1, 2));
        }
    }
}
