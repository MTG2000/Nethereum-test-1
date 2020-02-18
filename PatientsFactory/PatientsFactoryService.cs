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
using MedicalOperations.Contracts.PatientsFactory.ContractDefinition;

namespace MedicalOperations.Contracts.PatientsFactory
{
    public partial class PatientsFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PatientsFactoryDeployment patientsFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientsFactoryDeployment>().SendRequestAndWaitForReceiptAsync(patientsFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PatientsFactoryDeployment patientsFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientsFactoryDeployment>().SendRequestAsync(patientsFactoryDeployment);
        }

        public static async Task<PatientsFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PatientsFactoryDeployment patientsFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, patientsFactoryDeployment, cancellationTokenSource);
            return new PatientsFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PatientsFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddClinicRequestAsync(AddClinicFunction addClinicFunction)
        {
             return ContractHandler.SendRequestAsync(addClinicFunction);
        }

        public Task<TransactionReceipt> AddClinicRequestAndWaitForReceiptAsync(AddClinicFunction addClinicFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addClinicFunction, cancellationToken);
        }

        public Task<string> AddClinicRequestAsync(string clinicAddress)
        {
            var addClinicFunction = new AddClinicFunction();
                addClinicFunction.ClinicAddress = clinicAddress;
            
             return ContractHandler.SendRequestAsync(addClinicFunction);
        }

        public Task<TransactionReceipt> AddClinicRequestAndWaitForReceiptAsync(string clinicAddress, CancellationTokenSource cancellationToken = null)
        {
            var addClinicFunction = new AddClinicFunction();
                addClinicFunction.ClinicAddress = clinicAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addClinicFunction, cancellationToken);
        }

        public Task<string> AddressToPatientQueryAsync(AddressToPatientFunction addressToPatientFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressToPatientFunction, string>(addressToPatientFunction, blockParameter);
        }

        
        public Task<string> AddressToPatientQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var addressToPatientFunction = new AddressToPatientFunction();
                addressToPatientFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<AddressToPatientFunction, string>(addressToPatientFunction, blockParameter);
        }

        public Task<bool> ClinicsQueryAsync(ClinicsFunction clinicsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ClinicsFunction, bool>(clinicsFunction, blockParameter);
        }

        
        public Task<bool> ClinicsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var clinicsFunction = new ClinicsFunction();
                clinicsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<ClinicsFunction, bool>(clinicsFunction, blockParameter);
        }

        public Task<bool> IsOwnerQueryAsync(IsOwnerFunction isOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        
        public Task<bool> IsOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(null, blockParameter);
        }

        public Task<string> NewPatientRequestAsync(NewPatientFunction newPatientFunction)
        {
             return ContractHandler.SendRequestAsync(newPatientFunction);
        }

        public Task<TransactionReceipt> NewPatientRequestAndWaitForReceiptAsync(NewPatientFunction newPatientFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newPatientFunction, cancellationToken);
        }

        public Task<string> NewPatientRequestAsync(string address)
        {
            var newPatientFunction = new NewPatientFunction();
                newPatientFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(newPatientFunction);
        }

        public Task<TransactionReceipt> NewPatientRequestAndWaitForReceiptAsync(string address, CancellationTokenSource cancellationToken = null)
        {
            var newPatientFunction = new NewPatientFunction();
                newPatientFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newPatientFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PatientsNumQueryAsync(PatientsNumFunction patientsNumFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PatientsNumFunction, BigInteger>(patientsNumFunction, blockParameter);
        }

        
        public Task<BigInteger> PatientsNumQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PatientsNumFunction, BigInteger>(null, blockParameter);
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
