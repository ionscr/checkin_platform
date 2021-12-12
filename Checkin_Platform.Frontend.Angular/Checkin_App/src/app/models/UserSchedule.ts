import { Schedule } from "./Schedule";
import { User } from "./User";

export interface UserSchedule{
    Id?: number;
    User: User;
    Schedule: Schedule;
}