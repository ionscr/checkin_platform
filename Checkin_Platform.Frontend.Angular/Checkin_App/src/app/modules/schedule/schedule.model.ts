import { Class } from "../class/class.model";
import { Classroom } from "../classroom/classroom.model";

export interface Schedule{
    Id?: number;
    DateTime: Date;
    Classroom: Classroom;
    Class: Class;
}