import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Schedule } from 'src/app/models/schedule.model';
import { User } from 'src/app/models/user.model';
import { LoginService } from 'src/app/services/login/login.service';
import { RefreshService } from 'src/app/services/refresh/refresh.service';
import { UserService } from 'src/app/services/user/user.service';
import { UserScheduleService } from 'src/app/services/userschedule/userschedule.service';
import { ScheduleDetailsComponent } from '../dialogs/schedule-details/schedule-details.component';
import { ScheduleEditComponent } from '../dialogs/schedule-edit/schedule-edit.component';

@Component({
  selector: 'app-schedule-item',
  templateUrl: './schedule-item.component.html',
  styleUrls: ['./schedule-item.component.scss'],
})
export class ScheduleItemComponent implements OnInit {
  @Input() schedule: Schedule;
  currentUsers: User[] = [];
  logged: boolean = false;
  loggedUser: User;
  totalCapacity: number = -1;
  hasReservation: boolean = false;
  constructor(
    private userService: UserService,
    private loginService: LoginService,
    private userScheduleService: UserScheduleService,
    private refreshService: RefreshService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getCapacity();
    this.logged = this.loginService.getLogged();
    if (this.logged) this.loggedUser = this.loginService.getUser();
    this.getUsers();
  }
  getUsers() {
    if (this.schedule.Id != undefined && this.schedule.Users != undefined) {
      this.currentUsers = this.schedule.Users;
      if (this.logged) {
        if (this.currentUsers.find((u) => u.Id == this.loggedUser.Id))
          this.hasReservation = true;
        else this.hasReservation = false;
      }
      // this.userService
      //   .GetUsersBySchedule(this.schedule.Id)
      //   .subscribe((users) => {
      //     this.currentUsers = users;
      //     if (this.logged)
      //       if (users.find((u) => u.Id == this.loggedUser.Id))
      //         this.hasReservation = true;
      //       else this.hasReservation = false;
      //   });
    }
  }
  getCapacity() {
    this.totalCapacity = this.schedule.Classroom.Capacity;
  }
  openDetails() {
    const dialogRef = this.dialog.open(ScheduleDetailsComponent, {
      data: {
        schedule: this.schedule,
        reservations: this.currentUsers.length,
        user: this.loggedUser,
        hasReservation: this.hasReservation,
      },
    });
    dialogRef.afterClosed().subscribe(() => {
      this.getUsers();
    });
  }
  editDetails() {
    const dialogRef = this.dialog.open(ScheduleEditComponent, {
      data: {
        schedule: this.schedule,
      },
    });
    dialogRef.afterClosed().subscribe(() => {
      this.getUsers();
      this.refreshService.callRefresh();
    });
  }
  addReservation() {
    if (this.loggedUser.Id != undefined && this.schedule.Id != undefined) {
      var us = { UserId: this.loggedUser.Id, ScheduleId: this.schedule.Id };
      this.userScheduleService.CreateUserSchedule(us).subscribe((val) => {
        if (val) {
          this.currentUsers.push(this.loggedUser);
          this.hasReservation = true;
        }
      });
    }
  }
  removeReservation() {
    if (this.loggedUser.Id != undefined && this.schedule.Id != undefined) {
      var us = { UserId: this.loggedUser.Id, ScheduleId: this.schedule.Id };
      this.userScheduleService.DeleteUserSchedule(us).subscribe((val) => {
        if (val) {
          this.currentUsers = this.currentUsers.filter(
            (u) => u.Id != this.loggedUser.Id
          );
          this.hasReservation = false;
        }
      });
    }
  }
}
