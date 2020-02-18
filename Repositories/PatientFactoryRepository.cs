using System;
using System.Threading.Tasks;
using MedicalOperations.Contracts.PatientsFactory;
using MedicalOperations.Contracts.PatientsFactory.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Util;
namespace MedicalOperations.Repositories
{
    class PatientFactoryRepository
    {

        private static string clientUrl = "http://localhost:8545";
        private static string contractAddress;


        static public void Initialize(string _clientUrl, string _contractAddress)
        {
            clientUrl = _clientUrl;
            contractAddress = _contractAddress;
        }

        public static async Task<string> DeployContract(Account account, string _clientUrl)
        {

            Console.WriteLine("Deploying...");
            var web3 = new Web3(account, _clientUrl);
            var deployment = new PatientsFactoryDeployment();
            var receipt = await PatientsFactoryService.DeployContractAndWaitForReceiptAsync(web3, deployment);

            clientUrl = _clientUrl;
            contractAddress = receipt.ContractAddress;

            Console.WriteLine($"Contract Address: {contractAddress}");
            Console.WriteLine("");
            return contractAddress;
        }


        static PatientsFactoryService GetService()
        {
            var web3 = new Web3(clientUrl);
            var service = new PatientsFactoryService(web3, contractAddress);
            return service;

        }
        static PatientsFactoryService GetService(Account account)
        {
            var web3 = new Web3(account, clientUrl);
            var service = new PatientsFactoryService(web3, contractAddress);
            return service;

        }

        public static async Task NewClinic(Account account, string _ClinicAddress)
        {

            var service = GetService(account);
            var receiptForAddClinicCall = await service.AddClinicRequestAndWaitForReceiptAsync(
                new AddClinicFunction() { ClinicAddress = _ClinicAddress });
            Console.WriteLine("Clinic Added Successfully");
            Console.WriteLine("");

        }

        public static async Task<(string, string)> NewPatient(Account account)
        {
            var service = GetService(account);

            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            var patientAccount = new Account(privateKey);

            var recipt = await service.AddressToPatientQueryAsync(
                new AddressToPatientFunction() { ReturnValue1 = patientAccount.Address }
            );
            // Generate an unused address
            while (!IsAddressZero(recipt))
            {
                ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
                patientAccount = new Account(privateKey);

                recipt = await service.AddressToPatientQueryAsync(
                   new AddressToPatientFunction() { ReturnValue1 = patientAccount.Address }
               );
            }

            await service.NewPatientRequestAndWaitForReceiptAsync(
                new NewPatientFunction()
                {
                    Address = patientAccount.Address
                }
            );

            var patientContractAddress = await GetPatientContract(patientAccount.Address);

            return (patientAccount.PrivateKey, patientContractAddress);
        }

        static bool IsAddressZero(string address)
        {
            return address == "0x0000000000000000000000000000000000000000";
        }


        public static async Task<string> GetPatientContract(string address)
        {

            var service = GetService();

            return await service.AddressToPatientQueryAsync(
                new AddressToPatientFunction() { ReturnValue1 = address }
            );


        }
        public static async Task<bool> ClinicExist(string _ClinicAddress)
        {

            var service = GetService();

            return await service.ClinicsQueryAsync(
                new ClinicsFunction() { ReturnValue1 = _ClinicAddress }
            );


        }

    }
}