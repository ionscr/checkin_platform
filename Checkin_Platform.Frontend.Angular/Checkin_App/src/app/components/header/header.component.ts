import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../dialogs/login/login.component';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  title: string = 'Check-in Platform';
  logged: boolean = false;
  currentUser?: User;
  constructor(private loginService: LoginService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.loginService.loggedChange.subscribe((value) => (this.logged = value));
    this.logged = this.loginService.getLogged();
    if (this.logged) this.currentUser = this.loginService.getUser();
  }

  LogIn() {
    const dialogRef = this.dialog.open(LoginComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result != undefined) this.loginService.logIn(result);
      if (this.logged) this.currentUser = this.loginService.getUser();
    });
  }
  LogOut() {
    this.loginService.logOut();
  }
}
