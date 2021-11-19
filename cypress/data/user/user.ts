import buildAddress from "../address/buildAddress";
import Address from "../address/address";

export default class User {
    firstName: string;
    lastName: string; 
    address: Address;
    dateOfBirth: Date;
    gender: Gender;

    constructor () {
        this.firstName = "";
        this.lastName = "";
        this.address = buildAddress();
        this.dateOfBirth = new Date();
        this.gender = 0; 
    }
}

export enum Gender {
    Female = 0,
    Male = 1
}