import { Class } from "./Class";
import { Classroom } from "./Classroom";

export interface Schedule{
    Id?: number;
    DateTime: Date;
    Classroom: Classroom;
    Class: Class;
}