import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../dialogs/login/login.component';
import { User } from 'src/app/models/user.model';
import { ManageClassesComponent } from '../dialogs/manage-classes/manage-classes.component';
import { ManageClassroomsComponent } from '../dialogs/manage-classrooms/manage-classrooms.component';
import { ManageFeaturesComponent } from '../dialogs/manage-features/manage-features.component';
import { ManageUsersComponent } from '../dialogs/manage-users/manage-users.component';
import { ManageSchedulesComponent } from '../dialogs/manage-schedules/manage-schedules.component';
import { RefreshService } from 'src/app/services/refresh/refresh.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  title: string = 'Check-in Platform';
  logged: boolean = false;
  currentUser?: User;
  constructor(
    private loginService: LoginService,
    public dialog: MatDialog,
    private refreshService: RefreshService
  ) {}

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
      this.refreshService.callRefresh();
    });
  }
  LogOut() {
    this.loginService.logOut();
    this.refreshService.callRefresh();
  }
  manageClasses() {
    const dialogRef = this.dialog.open(ManageClassesComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.refreshService.callRefresh();
    });
  }
  manageClassrooms() {
    const dialogRef = this.dialog.open(ManageClassroomsComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.refreshService.callRefresh();
    });
  }
  manageFeatures() {
    const dialogRef = this.dialog.open(ManageFeaturesComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.refreshService.callRefresh();
    });
  }
  manageSchedules() {
    const dialogRef = this.dialog.open(ManageSchedulesComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.refreshService.callRefresh();
    });
  }
  manageUsers() {
    const dialogRef = this.dialog.open(ManageUsersComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.refreshService.callRefresh();
    });
  }
}
