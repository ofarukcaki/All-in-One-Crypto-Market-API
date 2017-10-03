using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace crytoAPI.Markets
{
    public class bitfinex
    {
        public static string output;
        public static Bitfinex myMarket = new Bitfinex();

        public static string equations(string pair)
        {
            if (pair == "usd")
            {
                pair = "btcusd";
            }
            return pair;
        }

        public static Bitfinex getdata(string pair)
        {
            pair = pair == "fiat" ? "usd" : pair;
            pair = equations(pair);

            try
            {
                var task = fetchdata(pair);
                task.Wait();

                //return "asd";
                return myMarket;
            }
            catch
            {
                return null;
            }

            //return  fetchdata(pair).ToString();

        }

        public static async Task fetchdata(string pair)
        {
            var client = new HttpClient();
            var fullurl = "https://api.bitfinex.com/v1/pubticker/" + pair;
            var result = await client.GetStringAsync(fullurl);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(result);

            //Bitfinex myMarket = new Bitfinex();
            myMarket.ask = r.ask;
            myMarket.bid = r.bid;
            myMarket.last = r.last_price;
            myMarket.volume = r.volume;
            myMarket.high = r.high;
            myMarket.low = r.low;


            //string output = JsonConvert.SerializeObject(myMarket);
            //output = myMarket;
            System.Diagnostics.Debug.WriteLine(myMarket);


        }

        public class Bitfinex
        {
            public string ask { get; set; }
            public string bid { get; set; }
            public string last { get; set; }
            public string volume { get; set; }
            public string high { get; set; }
            public string low { get; set; }
        }
        public class RootObject
        {
            public string mid { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string last_price { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string volume { get; set; }
            public string timestamp { get; set; }
        }
    }
}
