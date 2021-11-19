import faker from "faker";
import Address from "./address";

export default function createNew(){
    let address:Address = new Address();
    address.firstLine = faker.address.streetAddress();
    address.secondLine = faker.address.streetName();
    address.postcode = faker.address.zipCode();
    address.city = faker.address.city();
    return address;
}