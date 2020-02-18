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
using MedicalOperations.Contracts.Patient.ContractDefinition;

namespace MedicalOperations.Contracts.Patient
{
    public partial class PatientService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PatientDeployment patientDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientDeployment>().SendRequestAndWaitForReceiptAsync(patientDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PatientDeployment patientDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientDeployment>().SendRequestAsync(patientDeployment);
        }

        public static async Task<PatientService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PatientDeployment patientDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, patientDeployment, cancellationTokenSource);
            return new PatientService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PatientService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsOwnerQueryAsync(IsOwnerFunction isOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        
        public Task<bool> IsOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(null, blockParameter);
        }

        public Task<string> NewRecordRequestAsync(NewRecordFunction newRecordFunction)
        {
             return ContractHandler.SendRequestAsync(newRecordFunction);
        }

        public Task<TransactionReceipt> NewRecordRequestAndWaitForReceiptAsync(NewRecordFunction newRecordFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newRecordFunction, cancellationToken);
        }

        public Task<string> NewRecordRequestAsync(string data, string encryptedKey1, string encryptedKey2)
        {
            var newRecordFunction = new NewRecordFunction();
                newRecordFunction.Data = data;
                newRecordFunction.EncryptedKey1 = encryptedKey1;
                newRecordFunction.EncryptedKey2 = encryptedKey2;
            
             return ContractHandler.SendRequestAsync(newRecordFunction);
        }

        public Task<TransactionReceipt> NewRecordRequestAndWaitForReceiptAsync(string data, string encryptedKey1, string encryptedKey2, CancellationTokenSource cancellationToken = null)
        {
            var newRecordFunction = new NewRecordFunction();
                newRecordFunction.Data = data;
                newRecordFunction.EncryptedKey1 = encryptedKey1;
                newRecordFunction.EncryptedKey2 = encryptedKey2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newRecordFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RecordsQueryAsync(RecordsFunction recordsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RecordsFunction, string>(recordsFunction, blockParameter);
        }

        
        public Task<string> RecordsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var recordsFunction = new RecordsFunction();
                recordsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<RecordsFunction, string>(recordsFunction, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }
    }
}
