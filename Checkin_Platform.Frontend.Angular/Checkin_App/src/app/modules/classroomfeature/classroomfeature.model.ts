import { Classroom } from "../classroom/classroom.model";
import { Feature } from "../feature/feature.model";


export interface ClassroomFeature{
    Id?: number;
    Feature: Feature;
    Classroom: Classroom;
}