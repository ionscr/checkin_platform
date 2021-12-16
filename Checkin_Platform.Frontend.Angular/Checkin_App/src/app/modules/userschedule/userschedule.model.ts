import { Schedule } from "../schedule/schedule.model";
import { User } from "../user/user.model";


export interface UserSchedule{
    Id?: number;
    User: User;
    Schedule: Schedule;
}