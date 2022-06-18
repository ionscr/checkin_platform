export interface User {
  Id?: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Role: string;
  Year?: number;
  Department?: string;
  Group?: string;
}

export interface UserLoginData {
  Email: string;
  Password: string;
}
