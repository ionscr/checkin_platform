import { Class } from './class.model';
import { Classroom } from './classroom.model';

export interface Schedule {
  Id?: number;
  DateTime: string;
  Classroom: Classroom;
  Class: Class;
}

export interface ScheduleGroup {
  Date: Date;
  Schedules: Schedule[];
}

export interface ScheduleDto {
  DateTime: string;
  ClassroomId: number;
  ClassId: number;
}
