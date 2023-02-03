// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS8764 // Nullability of return type doesn't match overridden member (possibly because of nullability attributes).
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace HW3
{
    using System.Numerics;
    using System.Text;

    public class FibonacciTextReader : System.IO.TextReader
    {
        private int lineNum = 0;
        private BigInteger secondPrevious = 0;
        private BigInteger previous = 1;
        private int max;

        public FibonacciTextReader(int maxLines)
        {
            this.max = maxLines;
        }

        /// <summary>
        /// Returns the next number in the Fibonacci Sequence as a string.
        /// </summary>
        /// <returns>String containing the next number in the Fibonacci sequence.</returns>
        public override string? ReadLine()
        {
            if (this.lineNum + 1 >= this.max)
            {
                return null;
            }
            else if (this.lineNum == 0)
            {
                this.lineNum++;
                return "1. 0\r\n";
            }
            else if (this.lineNum == 1)
            {
                this.lineNum++;
                return "2. 1\r\n";
            }
            else
            {
                this.lineNum++;
                BigInteger temp = this.secondPrevious + this.previous;
                this.secondPrevious = this.previous;
                this.previous = temp;
                return this.lineNum.ToString() + ". " + temp.ToString() + "\r\n";
            }
        }

        /// <summary>
        /// Gets returns numbers in the Fibonacci sequence until max is hit.
        /// </summary>
        /// <returns>String containing the numbers in the Fibonacci sequence.</returns>
        public override string? ReadToEnd()
        {
            string currentReturn = ReadLine();

            if (currentReturn == null)
            {
                return null;
            }

            StringBuilder? fullSequence = new StringBuilder(currentReturn);
            currentReturn = this.ReadLine();
            while (currentReturn != null)
            {
                fullSequence.Append(currentReturn);

                currentReturn = this.ReadLine();
            }

            return fullSequence.ToString();
        }
    }
}