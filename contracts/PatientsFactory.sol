pragma solidity ^0.6.0;

import "./Ownable.sol";
import "./Patient.sol";

contract PatientsFactory is Ownable {
    mapping(address => address) public addressToPatient;
    Patient[] patients;
    uint256 public patientsNum = 0;
    mapping(address => bool) public clinics;

    modifier onlyClinic() {
        require(clinics[msg.sender], "Only clinics are allowed");
        _;
    }

    function addClinic(address _clinicAddress) external onlyOwner {
        clinics[_clinicAddress] = true;
    }

    function newPatient(address _address)
        external
        onlyClinic
        returns (address)
    {
        require(
            addressToPatient[_address] == address(0),
            "Address Already Taken"
        );
        Patient patient = new Patient(address(this));
        //set the ownership of the patient contract to him
        patient.transferOwnership(_address);
        //reserve an address for him and add the Contract to the array
        addressToPatient[_address] = address(patient);
        return addressToPatient[_address]; //the address of the new patient contract
    }

}
