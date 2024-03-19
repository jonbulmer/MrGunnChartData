using Microsoft.Extensions.Logging;
using MrGunnChartData.DataLayer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System.Numerics;
using System.Globalization;
using Nethereum.Contracts.QueryHandlers.MultiCall;

namespace MrGunnChartData.EvmLayer
{
    public class ReadContract : IReadContract
    {

        private readonly IPlsTimeChartRepository _plsTimeChartRepository;

        public ReadContract(IPlsTimeChartRepository plsTimeChartRepository)
        {
            _plsTimeChartRepository = plsTimeChartRepository;
        }

        public long ReturnTotalSupply()
        {
            var web3 = new Web3("https://pulsechain-rpc.publicnode.com");

            var abi = _plsTimeChartRepository.ReturnJson("TimeContractAbi");
            var function = web3.Eth.GetContract(abi, "0xCA35638A3fdDD02fEC597D8c1681198C06b23F58")
                                                   .GetFunction("claimableDividendOf");

            var data = function.GetData(""); 

            var call = new CallInput(data, "0xCA35638A3fdDD02fEC597D8c1681198C06b23F58");
            var task = function.CallAsync(call);
            task.Wait();

            var result = task.Result;


            return 3; //  balance;
        }

        public long HexToDecimal(string HexNumber)
        {
            HexNumber = HexNumber.Replace("0x", "");
            long decValue = long.Parse(HexNumber, NumberStyles.HexNumber);

            return decValue;
        }

     
    }
}