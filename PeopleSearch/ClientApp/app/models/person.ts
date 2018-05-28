import { Address } from '../models/address';

export interface Person {
    id: number;
    firstName: string;
    lastName: string;
    address: Address;
    age: number;
    interests: string;
}
