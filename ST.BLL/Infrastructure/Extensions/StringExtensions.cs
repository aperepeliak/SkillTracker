using ST.BLL.DTOs;
using System;

namespace ST.BLL.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static bool Operator(this ComparerType logic, int x, int y)
        {
            switch (logic)
            {
                case ComparerType.GreaterThan: return x > y;
                case ComparerType.LessThan: return x < y;
                case ComparerType.Equals: return x == y;
                default: throw new Exception("invalid logic");
            }
        }
    }
}
