using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using MedicalOperations.Contracts.Record.ContractDefinition;

namespace MedicalOperations.Contracts.Record
{
    public partial class RecordService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RecordDeployment recordDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RecordDeployment>().SendRequestAndWaitForReceiptAsync(recordDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RecordDeployment recordDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RecordDeployment>().SendRequestAsync(recordDeployment);
        }

        public static async Task<RecordService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RecordDeployment recordDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, recordDeployment, cancellationTokenSource);
            return new RecordService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RecordService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddressToEncryptedKeysQueryAsync(AddressToEncryptedKeysFunction addressToEncryptedKeysFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressToEncryptedKeysFunction, string>(addressToEncryptedKeysFunction, blockParameter);
        }

        
        public Task<string> AddressToEncryptedKeysQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var addressToEncryptedKeysFunction = new AddressToEncryptedKeysFunction();
                addressToEncryptedKeysFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<AddressToEncryptedKeysFunction, string>(addressToEncryptedKeysFunction, blockParameter);
        }

        public Task<string> DataQueryAsync(DataFunction dataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DataFunction, string>(dataFunction, blockParameter);
        }

        
        public Task<string> DataQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DataFunction, string>(null, blockParameter);
        }
    }
}
