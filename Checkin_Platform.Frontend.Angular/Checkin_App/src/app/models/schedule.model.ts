import { Class } from './class.model';
import { Classroom } from './classroom.model';

export interface Schedule {
  Id?: number;
  DateTime: Date;
  Classroom: Classroom;
  Class: Class;
}
