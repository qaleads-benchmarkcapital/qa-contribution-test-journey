import User from "./user";
import getRandomInt  from "../../common/getRandomInt";
import faker from "faker";

export default function createNew(){
    let user:User = new User();
    user.firstName = faker.name.firstName();
    user.lastName = faker.name.lastName();
    user.gender = getRandomInt(0,2);
    user.dateOfBirth.setFullYear(user.dateOfBirth.getFullYear() - getRandomInt(18, 56));
}