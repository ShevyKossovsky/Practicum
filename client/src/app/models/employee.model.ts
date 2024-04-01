import { EmployeePosition } from "./employeePosition.model";

export class Employee {
    id!: number;
    firstName!: string;
    lastName!: string;
    idNumber!: string;
    gender!: number;
    employmentStartDate!: Date;
    dateOfBirth!: Date;
    positionsList!: EmployeePosition[];
}
export enum EGender
{
    Male ,
    Female
}