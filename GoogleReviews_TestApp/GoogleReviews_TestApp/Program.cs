using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using YelpSharp;

//using Google.Apis.

namespace GoogleReviews_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new YelpAPIClient();
            obj.PerformRequest();
            Console.Read();
        }
    }
}
 