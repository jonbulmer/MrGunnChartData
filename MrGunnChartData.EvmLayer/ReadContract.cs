using Microsoft.Extensions.Logging;
using MrGunnChartData.Utilities;
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
using System.Runtime.ConstrainedExecution;

namespace MrGunnChartData.EvmLayer
{
    public class ReadContract : IReadContract
    {

        private readonly IJsonUtility _jsonUtility;

        public ReadContract(IJsonUtility jsonUtility)
        {
            _jsonUtility = jsonUtility;
        }

        public long ReturnPlsEarned100KTime(long lastPlsEarned)
        {
            var web3 = new Web3("https://pulsechain-rpc.publicnode.com");

            var abi = _jsonUtility.ReturnJson("TimeContractAbi");
            var function = web3.Eth.GetContract(abi, "0xCA35638A3fdDD02fEC597D8c1681198C06b23F58")
                                                   .GetFunction("claimableDividendOf");

            var data = function.GetData("0x720687ceefacb788692dbc4ea38424c4733ddac2"); 

            var call = new CallInput(data, "0xCA35638A3fdDD02fEC597D8c1681198C06b23F58");
            var task = function.CallAsync(call);
            task.Wait();

            var callResult = task.Result;

            var decimalReturn = HexToDecimal(callResult);

            var result = Convert.ToDouble(decimalReturn.Substring(0, decimalReturn.Length - 18));

            result = (result / 137 * 100) - lastPlsEarned; 

            return (long)Math.Floor(result);
        }

        public string HexToDecimal(string hexNumber)
        {
            hexNumber = hexNumber.Replace("0x", "");

            var hexConst = BigInteger.Parse("16");
            var powResult = BigInteger.Parse("0");
            var result = BigInteger.Parse("0"); 

            for (int i = hexNumber.Length - 1; i > 0; i--)
            {
                powResult = BigInteger.Pow(hexConst, hexNumber.Length - (i+1) );
                result = result + (HexChar(hexNumber[i]) * powResult); 
            }

            return result.ToString();
        }
        
        public int HexChar(char character)
        {
            var result = int.Parse(character.ToString(), NumberStyles.HexNumber);
            return int.Parse(character.ToString(), NumberStyles.HexNumber);
        }
    }
}