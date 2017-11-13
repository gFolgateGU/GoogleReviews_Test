using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleReviews_TestApp
{
    public class YelpAPIClient
    {
        private const string HOST = "https://api.yelp.com/v3/businesses/search?location=erie&term=golf";
        private const string HOST2 = "https://api.yelp.com/v3/businesses/elk-valley-golf-course-girard";
        private const string HOST3 = "https://api.yelp.com/v3/businesses/whispering-woods-golf-club-pro-shop-erie/reviews";

        public YelpAPIClient()
        {
            
        }

        public async Task<string> PerformRequest()
        {
            var uriBuilder = new UriBuilder(HOST3);

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Headers.Add("Authorization", "Bearer yqCRRvNvxvLQi1f_EBTlaHXC7LURwVTt80PXTUxabfYPxvmsfQJXw6lFxyizBwCdaYsFxTkiy9fPGzdv_2C2Li6MfCAv1LFBL-HwrZTQjR1KUwZu1_GEgwO6LvUFWnYx");
            request.Headers.Add("Content_Type", "application/x-www-form-urlencoded");
            request.Method = "GET";

            try
            {
                var httpResponse = await request.GetResponseAsync() as HttpWebResponse;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
                {
                    var x = JObject.Parse(streamReader.ReadToEnd());
                    //Console.WriteLine(x);
                    var reviews = (JArray)x.GetValue("reviews");
                    var z = GenerateGolfCourseReviewsList(reviews);
                    return "dude right there";
                }
            }
            catch (WebException webException)
            {
                Console.WriteLine("Right dude here dude");
                Console.WriteLine(webException.Status);
            }
            return null;
        }

        private IEnumerable<YelpGolfCourseReview> GenerateGolfCourseReviewsList(JArray reviews)
        {
            var golfCourseReviewList = new List<YelpGolfCourseReview>();
            foreach (var review in reviews)
            {
                golfCourseReviewList.Add(new YelpGolfCourseReview
                {
                    DatePosted = (DateTime)review["time_created"],
                    Rating = (int)review["rating"],
                    Text = (string)review["text"],
                    User = (string)review["user"]["name"]
                });
            }
            foreach (var golfCourseReview in golfCourseReviewList)
            {
                Console.WriteLine(golfCourseReview.Rating);
                Console.WriteLine(golfCourseReview.DatePosted);
                Console.WriteLine(golfCourseReview.Text);
                Console.WriteLine(golfCourseReview.User);
            }
            return golfCourseReviewList;
        }
    }
}
