import { Schedule } from './schedule.model';
import { User } from './user.model';

export interface UserSchedule {
  Id?: number;
  User: User;
  Schedule: Schedule;
}
