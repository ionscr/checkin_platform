import { User } from "./User";

export interface Class{
    Id?: number;
    Name: string;
    Teacher: User;
    Year: number;
    Section: string;
}