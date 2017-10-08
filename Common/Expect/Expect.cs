using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Expect
{
    public static class Expect
    {
        public static void ArgumentNotNull<T>(T agrument, string name)
        {
            if (agrument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void AgrumentNotEmpty(string argument, string name)
        {
            if (argument == string.Empty)
            {
                throw new ArgumentException(name);
            }
        }
    }
}
