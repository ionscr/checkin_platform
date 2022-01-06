import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  selectedRole: String = '';
  roles: String[] = [];
  selectedUser?: User;
  users: User[] = [];
  usersByRole: User[] = [];
  constructor(
    private dialogRef: MatDialogRef<LoginComponent>,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userService.GetUsers().subscribe((users) => {
      this.users = users;
    });
    this.userService.GetRoles().subscribe((roles) => {
      this.roles = roles;
    });
  }
  roleChange($event: MatSelectChange) {
    this.selectedRole = $event.value;
    this.usersByRole = this.users.filter((u) => u.Role == $event.value);
  }
  close() {
    this.dialogRef.close();
  }
  logIn() {
    this.dialogRef.close(this.selectedUser);
  }
}
