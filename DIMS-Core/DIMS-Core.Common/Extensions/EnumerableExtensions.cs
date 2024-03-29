﻿using System.Collections.Generic;

namespace DIMS_Core.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static string ToSeparatedString(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}