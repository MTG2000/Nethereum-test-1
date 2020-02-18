using System;
using System.Threading.Tasks;
using MedicalOperations.Repositories;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;

namespace MedicalOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo().Wait();
        }

        static async Task Demo()
        {
            try
            {
                // Setup Constants
                var url = "http://localhost:8545";
                // var ownerPrvKey = "d2629a98993eec8d54f6ba4442f3154d1e12e04fda498750c6f3145741e39d96";
                var clinic1_PrvKey = "769de1f1a9dd6e114f81b9490ea42a2967840353edd358a35c84e2c831dd40a2";
                var contractAddress = "0x3d6a6d363580df988521fe0652b3f03164635b1d";
                var patient1_PrvKey = "0xc662ee09e119236fa5ce9a3c84b150a6648d729e19b7e9509fcf6760280ac9";
                var patient2_PrvKey = "0x0e65e4d9da1df334929ca8cbbdf8e5e666d277e5d525aac00a1c56d0fcedd23b";

                //Generate a random Private Key
                // var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                // var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();

                //  var contractAddress = await PatientFactoryRepository.DeployContract(new Account(ownerPrvKey), url);

                PatientFactoryRepository.Initialize(url, contractAddress);

                // await PatientFactoryRepository.NewClinic(new Account(ownerPrvKey), account.Address);

                // Console.WriteLine(await PatientFactoryRepository.ClinicExist(new Account(clinic1_PrvKey).Address));
                // Console.WriteLine(await PatientFactoryRepository.ClinicExist(new Account(ownerPrvKey).Address));

                // var clinitcAccount = new Account(clinic1_PrvKey);
                // var (newPatient_PrvKey, newPatient_ContractAddress) = await PatientFactoryRepository.NewPatient(clinitcAccount);
                // Console.WriteLine((newPatient_PrvKey, newPatient_ContractAddress));

                // Console.WriteLine(await PatientFactoryRepository.GetPatientContract(new Account(patient2_PrvKey).Address));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished");

        }







    }
}
