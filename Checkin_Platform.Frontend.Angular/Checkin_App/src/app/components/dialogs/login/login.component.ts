import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { User, UserLoginData } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);
  hide = true;
  showError = false;
  currentUser?: User;
  constructor(
    private dialogRef: MatDialogRef<LoginComponent>,
    private userService: UserService
  ) {}

  ngOnInit(): void {}
  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
  onWrongData() {
    this.showError = true;
    this.email.setValue('');
    this.password.setValue('');
  }
  close() {
    this.dialogRef.close();
  }
  logIn() {
    let loginData: UserLoginData = {
      Email: this.email.value,
      Password: this.password.value,
    };
    this.userService.LoginUser(loginData).subscribe(
      (u) => {
        this.currentUser = u;
      },
      () => {},
      () => {
        if (this.currentUser?.Id == -1) {
          this.onWrongData();
        } else this.dialogRef.close(this.currentUser);
      }
    );
    this.showError = false;
  }
}
