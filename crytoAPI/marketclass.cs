using crytoAPI.Markets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static crytoAPI.Markets.bitfinex;
using static crytoAPI.Markets.bitstamp;
using static crytoAPI.Markets.cex;

namespace crytoAPI
{
    //[Route("api")]
    public class marketclass : Controller
    {
        [HttpGet("api/all/{pair}")]
        public IActionResult GetAll(string pair)
        {
            pair = pair.ToLower();
            var results = new { bitfinex = bitfinex.getdata(pair), bitstamp = bitstamp.getdata(pair), cexio = cex.getdata(pair), btcturk = btcturk.getdata(pair) };
            return new JsonResult(results);
            /*
            switch (pair)
            {
                case "fiat":
                    //Bitfinex res1 = null;
                    //Bitstamp res2 = null;
                    //Cex res3 = null;
                    //Btcturk res4 = null;
                    //Parallel.Invoke(
                    //    () => res1 = bitfinex.getdata(pair),
                    //    () => res2 = bitstamp.getdata(pair),
                    //    () => res3 = cex.getdata(pair),
                    //    () => res4 = btcturk.getdata(pair)
                    //    );
                    //var results = new { bitfinex = res1, bitstamp = res2, cexio = res3, btcturk = res4 };
                    var results = new { bitfinex = bitfinex.getdata(pair), bitstamp = bitstamp.getdata(pair), cexio = cex.getdata(pair), btcturk = btcturk.getdata(pair) };
                    return new JsonResult(results);

                //case "usd":
                //    var resultsUsd = new { bitfinex = bitfinex.getdata(pair), bitstamp = bitstamp.getdata(pair), cexio = cex.getdata(pair), btcturk = btcturk.getdata(pair) };
                //    return new JsonResult(resultsUsd);
                default:
                    return NotFound();

            }
            */
        }

        [HttpGet("api/{market}/{pair}")]
        public IActionResult GetData(string market, string pair)
        {
            pair = pair.ToLower();

            switch (market)
            {
                case "bitfinex":
                    //pair = arrange.finexA(pair);
                    return new JsonResult(bitfinex.getdata(arrange.finexA(pair)));


                case "bitstamp":
                    return new JsonResult(bitstamp.getdata(pair));

                case "cex":
                    //pair = arrange.cexA(pair);
                    return new JsonResult(cex.getdata(pair));
                case "btcturk":
                    return new JsonResult(btcturk.getdata(pair));

                default:
                    return NotFound();
            }
        }
    }
}
