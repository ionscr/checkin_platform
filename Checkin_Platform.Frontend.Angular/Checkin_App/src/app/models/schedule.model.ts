import { Class } from './class.model';
import { Classroom } from './classroom.model';
import { User } from './user.model';

export interface Schedule {
  Id?: number;
  DateTime: string;
  Classroom: Classroom;
  Class: Class;
  Users?: User[];
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
