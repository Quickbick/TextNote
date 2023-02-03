// <copyright file="FibonacciTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type

namespace HW3.Tests
{
    public class FibonacciTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FibonacciReadLineStarterTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(3);
            string temp = testClass.ReadLine();
            Assert.That(testClass.ReadLine(), Is.EqualTo("2. 1\r\n"));
        }

        [Test]
        public void FibonacciReadLineStandardTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(50);
            string temp = testClass.ReadLine();
            temp = testClass.ReadLine();
            temp = testClass.ReadLine();
            temp = testClass.ReadLine();
            temp = testClass.ReadLine();
            Assert.That(testClass.ReadLine(), Is.EqualTo("6. 5\r\n"));
        }

        [Test]
        public void FibonacciReadLineNullTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(2);
            string temp = testClass.ReadLine();
            Assert.That(testClass.ReadLine(), Is.EqualTo(null));
        }

        [Test]
        public void FibonacciReadToEndStarterTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(3);
            Assert.That(testClass.ReadToEnd(), Is.EqualTo("1. 0\r\n2. 1\r\n"));
        }

        [Test]
        public void FibonacciReadToEndStandardTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(7);
            Assert.That(testClass.ReadToEnd(), Is.EqualTo("1. 0\r\n2. 1\r\n3. 1\r\n4. 2\r\n5. 3\r\n6. 5\r\n"));
        }

        [Test]
        public void FibonacciReadToEndNullTest()
        {
            HW3.FibonacciTextReader testClass = new FibonacciTextReader(1);
            Assert.That(testClass.ReadToEnd(), Is.EqualTo(null));
        }
    }
}