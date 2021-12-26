import { User } from './user.model';

export interface Class {
  Id?: number;
  Name: string;
  Teacher: User;
  Year: number;
  Section: string;
}
