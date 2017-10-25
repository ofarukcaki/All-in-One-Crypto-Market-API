#  All in one CryptoCurrency Market API

#### Collection of common crypto market APIs in single API in same format.  Written in `ASP.NET Core 2.0`

Designed to get markets datas from different platforms at once with a single API, in same format for all various markets.

### Edit the code / Contribute
+ Open the `crytoAPI.sln` solution file in Visual Studio and edit/test/develop the API.
+ **Pull request are welcome, fork this project and send any kind of updates/corrections in pull req.**
+ Project is on __active development__ , you can request any market or currency pair. I can do my best to update this project as your wishes.


### Install
Since it is written in **.NET Core** you can deploy your app on Cloud using *__Azure__*, or anywhere you want. Supports all operating systems thanks to [.Net Core](https://www.microsoft.com/net/core
)

**or**

use hosted API by me over my personal website(__not yet sorry :/__).


| Available Markets | Pair |
| ------------- | ---- |
| - Bitfinex      | $ usd|
| - Bitstamp    |$ usd |
| - Cex.io |$ usd|
| - BTCTurk |₺ try|

Altcoin markets are also will be added. Stay tuned.
### Usage
Example calls:

localhost:11644/api/**bitfinex**/**usd**

Replace `bitfinex` with any other available market to see their datas.

```javascript
{
    "ask": "4278.5",
    "bid": "4278.4",
    "last": "4278.5",
    "volume": "30272.21365286",
    "high": "4439.9",
    "low": "4210.1"
}

```


___


localhost:11644/api/**bitfinex**/**ltcbtc**

Replace `ltcbtc` with any other correct values, for example `/api/bitfinex/neobtc` will **not** work due to neo is not a correct call on bitfinex market.
```javascript
{
    "ask": "0.012076",
    "bid": "0.012069",
    "last": "0.01207",
    "volume": "65134.1915878",
    "high": "0.012234",
    "low": "0.012004"
}

```

___



localhost:11644/api/**all**/**fiat**

Returns **__BTC-FIAT__** datas in json. Markets with original pair different than `USD` will be returned in original currency, like as `btcturk` in this example. An extra `pair` is also returned with these type of markets.
```javascript
{
    "bitfinex": {
        "ask": "4283.4",
        "bid": "4283.3",
        "last": "4283.4",
        "volume": "30143.3918181",
        "high": "4439.9",
        "low": "4210.1"
    },
    "bitstamp": {
        "ask": "4274.99",
        "bid": "4274.53",
        "last": "4274.99",
        "volume": "12979.77900300",
        "high": "4425.00",
        "low": "4218.00"
    },
    "cexio": {
        "ask": "4324.8399",
        "bid": "4318.0653",
        "last": "4324.84",
        "volume": "1097.24535895",
        "high": "4480",
        "low": "4260.1629"
    },
    "btcturk": {
        "ask": "15200",
        "bid": "15158,56",
        "last": "15158,57",
        "volume": "152,81",
        "high": "15371,99",
        "low": "15100",
        "pair": "TRY"
    }
}

```

___


For the **USD** equations of all markets available in the API, use **__/api/all/usd__**

localhost:11644/api/**all**/**usd**
```javascript
same as above example, but for btcturk, output will be:
"btcturk": {
        "ask": "4248,6",
        "bid": "4241,7",
        "last": "4241,7",
        "volume": "152,24",
        "high": "4282,4",
        "low": "4213,7",
        "pair": "USD"
    }
    
```

### Steps to Deploy ASP.NET Core to IIS
Before you deploy, you need to make sure that WebHostBuilder is configured properly to use Kestrel and IIS. Your web.config should also exist

**Step 1: Publish to a File Folder**

**Step 2: Copy Files to Preferred IIS Location**
Now you need to copy your publish output to where you want the files to live. If you are deploying to a remote server, you may want to zip up the files and move to the server. If you are deploying to a local dev box, you can copy them locally.
You will notice that with ASP.NET core there is no bin folder and it potentially copies over a ton of different .NET dlls. Your application may also be an EXE file if you are targeting the full .NET Framework.

**Step 3: Create Application in IIS**
First, create a new IIS Application Pool. You will want to create one under the .NET CLR version of “No Managed Code“. Since IIS only works as a reverse proxy, it isn’t actually executing any .NET code.

Second, create your new application under your existing IIS Site, or create a new IIS site. Either way, you will want to pick your new IIS Application Pool and point it at the folder you copied your ASP.NET publish output files to.

**Step 4: Load Your App!**
At this point, your application should load just fine. If it does not, check the output logging from it. Within your web.config file you define how IIS starts up your ASP.NET Core process. Enable output logging by setting stdoutLogEnabled=true and you may also want to change the log output location as configured in stdoutLogFile.
