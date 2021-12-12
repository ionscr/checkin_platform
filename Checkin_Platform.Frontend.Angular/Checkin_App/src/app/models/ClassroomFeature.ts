import { Classroom } from "./Classroom";
import { Feature } from "./Feature";

export interface ClassroomFeature{
    Id?: number;
    Feature: Feature;
    Classroom: Classroom;
}