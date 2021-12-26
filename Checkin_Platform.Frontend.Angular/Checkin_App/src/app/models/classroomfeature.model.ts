import { Classroom } from './classroom.model';
import { Feature } from './feature.model';

export interface ClassroomFeature {
  Id?: number;
  Feature: Feature;
  Classroom: Classroom;
}
