using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Nito.AsyncEx;

//using Google.Apis.

namespace GoogleReviews_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => PerformRequest());
            Console.Read();
        }

        private static async Task PerformRequest()
        {
            var obj = new YelpAPIClient();
            await obj.PerformRequest();
        }
    }
}
 