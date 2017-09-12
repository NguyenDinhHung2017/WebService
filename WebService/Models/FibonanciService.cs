using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public static class FibonanciService
    {
        public static double CalculateFibonanci(int n)
        {
            ConfigureLog4Net.ConfigLog4Net("log4net.config");
            Logger.Info($"Calculate Fib n = {n}");
            if (n <= 0 || n >= 101) return -1;

            if (n == 1)
            {
                return 1;
            }

            var a = 0;
            var b = 1;
            var c = 1;

            for (var i = 1; i < n; i++)
            {
                c = b + a;
                a = b;
                b = c;
            }
            return c;
        }
    }
}