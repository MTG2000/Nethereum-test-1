pragma solidity ^0.6.0;

import "./Ownable.sol";
import "./Record.sol";
import "./PatientsFactory.sol";

contract Patient is Ownable {
    Record[] public records;
    PatientsFactory factory;

    constructor(address _address) public {
        factory = PatientsFactory(_address);
    }

    modifier onlyClinic() {
        require(factory.clinics(msg.sender), "Only clinics are allowed");
        _;
    }

    function newRecord(
        string calldata _data,
        string calldata _encryptedKey1, //for the owner
        string calldata _encryptedKey2 //for the clinic
    ) external onlyClinic {
        //Should add Check if the sender is a clinic
        Record record = new Record(
            _data,
            owner(),
            _encryptedKey1,
            msg.sender,
            _encryptedKey2
        );
        records.push(record);
    }
}
