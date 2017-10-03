using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crytoAPI
{
    public class arrange
    {
        public static string finexA(string pair)
        {
            //if (pair == "ltc-btc")
            //{
            //    return "ltcbtc";
            //}
            //else
            //{
            //    return pair;
            //}
            switch (pair)
            {
                case "ltc-btc":
                    return "ltcbtc";
                default:
                    return pair;                    
            }
        }
        public static string cexA(string pair)
        {
            if (pair == "ETHBTC")
            {
                return "ETH-BTC";
            }
            else
            {
                return pair;
            }
        }
    }
}

