using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FixerIoCore;
using System.Net;
using FixerSharp;



namespace crytoAPI.Markets
{
    public class btcturk
    {
        public static Btcturk usdData = new Btcturk();
        public static Btcturk tryData = new Btcturk();

        public static double truncate(double dbl)
        {
            var x = Math.Truncate(dbl);
            return x;
        }

        public static Btcturk getdata(string pair)
        {
            try
            {
                var task = fetchdata(pair);
                task.Wait();

                var result = (pair == "fiat") ? tryData : usdData;

                return result;
            }
            catch
            {
                return null;
            }
        }
        public static string toString(double x)
        {
            var y = x.ToString("N1").Replace(".", string.Empty);
            return y;
        }

        public static async Task fetchdata(string pair)
        {

            var client = new HttpClient();
            var fullurl = "https://www.btcturk.com/api/ticker";
            var result = await client.GetStringAsync(fullurl);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(result);

            double tryRate = Fixer.Convert("TRY", "USD", 1);

            if (pair == "fiat")
            {
                tryData.ask = r.ask.ToString();
                tryData.bid = r.bid.ToString();
                tryData.last = r.last.ToString();
                tryData.volume = r.volume.ToString();
                tryData.high = r.high.ToString();
                tryData.low = r.low.ToString();
                tryData.pair = "TRY";
            }
            else
            {
                usdData.ask = toString(r.ask * tryRate);
                usdData.bid = toString(r.bid * tryRate);
                usdData.last = toString(r.last * tryRate);
                usdData.volume = r.volume.ToString();
                usdData.high = toString(r.high * tryRate);
                usdData.low = toString(r.low * tryRate);
                usdData.pair = "USD";
            }



            //System.Diagnostics.Debug.WriteLine(usdData);


        }

    }


    public class Btcturk
    {
        public string ask { get; set; }
        public string bid { get; set; }
        public string last { get; set; }
        public string volume { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string pair { get; set; }
    }

    public class RootObject
    {
        public double high { get; set; }
        public double last { get; set; }
        public double timestamp { get; set; }
        public double bid { get; set; }
        public double volume { get; set; }
        public double low { get; set; }
        public double ask { get; set; }
        public double open { get; set; }
        public double average { get; set; }
    }


}
