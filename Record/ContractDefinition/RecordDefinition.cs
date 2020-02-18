using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace MedicalOperations.Contracts.Record.ContractDefinition
{


    public partial class RecordDeployment : RecordDeploymentBase
    {
        public RecordDeployment() : base(BYTECODE) { }
        public RecordDeployment(string byteCode) : base(byteCode) { }
    }

    public class RecordDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405161056a38038061056a833981810160405260a081101561003357600080fd5b810190808051604051939291908464010000000082111561005357600080fd5b90830190602082018581111561006857600080fd5b825164010000000081118282018810171561008257600080fd5b82525081516020918201929091019080838360005b838110156100af578181015183820152602001610097565b50505050905090810190601f1680156100dc5780820380516001836020036101000a031916815260200191505b5060408181526020830151920180519294919391928464010000000082111561010457600080fd5b90830190602082018581111561011957600080fd5b825164010000000081118282018810171561013357600080fd5b82525081516020918201929091019080838360005b83811015610160578181015183820152602001610148565b50505050905090810190601f16801561018d5780820380516001836020036101000a031916815260200191505b506040818152602083015192018051929491939192846401000000008211156101b557600080fd5b9083019060208201858111156101ca57600080fd5b82516401000000008111828201881017156101e457600080fd5b82525081516020918201929091019080838360005b838110156102115781810151838201526020016101f9565b50505050905090810190601f16801561023e5780820380516001836020036101000a031916815260200191505b5060405250508551610258915060009060208801906102b7565b506001600160a01b03841660009081526001602090815260409091208451610282928601906102b7565b506001600160a01b038216600090815260016020908152604090912082516102ac928401906102b7565b505050505050610352565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106102f857805160ff1916838001178555610325565b82800160010185558215610325579182015b8281111561032557825182559160200191906001019061030a565b50610331929150610335565b5090565b61034f91905b80821115610331576000815560010161033b565b90565b610209806103616000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c806306240aca1461003b57806373d4a13a146100d6575b600080fd5b6100616004803603602081101561005157600080fd5b50356001600160a01b03166100de565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561009b578181015183820152602001610083565b50505050905090810190601f1680156100c85780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b610061610178565b60016020818152600092835260409283902080548451600294821615610100026000190190911693909304601f81018390048302840183019094528383529192908301828280156101705780601f1061014557610100808354040283529160200191610170565b820191906000526020600020905b81548152906001019060200180831161015357829003601f168201915b505050505081565b6000805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156101705780601f106101455761010080835404028352916020019161017056fea264697066735822122068c30458ea1da7292130cface386ebe2353b4ae6edbc294b9685792be135ae3064736f6c63430006010033";
        public RecordDeploymentBase() : base(BYTECODE) { }
        public RecordDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "_data", 1)]
        public virtual string Data { get; set; }
        [Parameter("address", "_address1", 2)]
        public virtual string Address1 { get; set; }
        [Parameter("string", "_encryptedKey1", 3)]
        public virtual string EncryptedKey1 { get; set; }
        [Parameter("address", "_address2", 4)]
        public virtual string Address2 { get; set; }
        [Parameter("string", "_encryptedKey2", 5)]
        public virtual string EncryptedKey2 { get; set; }
    }

    public partial class AddressToEncryptedKeysFunction : AddressToEncryptedKeysFunctionBase { }

    [Function("addressToEncryptedKeys", "string")]
    public class AddressToEncryptedKeysFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DataFunction : DataFunctionBase { }

    [Function("data", "string")]
    public class DataFunctionBase : FunctionMessage
    {

    }

    public partial class AddressToEncryptedKeysOutputDTO : AddressToEncryptedKeysOutputDTOBase { }

    [FunctionOutput]
    public class AddressToEncryptedKeysOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DataOutputDTO : DataOutputDTOBase { }

    [FunctionOutput]
    public class DataOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
