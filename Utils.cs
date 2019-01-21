using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kill_particular_process
{
    public static class Utils
    {
        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}
