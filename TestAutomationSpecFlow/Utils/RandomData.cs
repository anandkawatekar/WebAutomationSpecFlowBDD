using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationSpecFlow.Utils
{
    public static class RandomData
    {
        public static string GetRandomString(int size)
        {
            var random = new Random();
            var builder = new StringBuilder(size);

            //char is a single unicode character
            char offset = 'a';
            const int lettersOffset = 26; //a...z length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();

        }

        public static string GetRandomNumbers(int size)
        {
            var random = new Random();
            var builder = new StringBuilder(size);

            //char is a single unicode character
            char offset = '0';
            const int lettersOffset = 10; //0...9 length=10

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();

        }
    }
}
