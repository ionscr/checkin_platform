import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Feature } from 'src/app/models/feature.model';
import { Schedule } from 'src/app/models/schedule.model';
import { User } from 'src/app/models/user.model';
import { FeatureService } from 'src/app/services/feature/feature.service';
import { UserScheduleService } from 'src/app/services/userschedule/userschedule.service';
export interface DialogData {
  schedule: Schedule;
  reservations: number;
  user: User;
  hasReservation: boolean;
}
@Component({
  selector: 'app-schedule-details',
  templateUrl: './schedule-details.component.html',
  styleUrls: ['./schedule-details.component.css'],
})
export class ScheduleDetailsComponent implements OnInit {
  schedule: Schedule;
  reservations: number = 0;
  features: Feature[] = [];
  user: User;
  hasReservation: boolean = false;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private dialogRef: MatDialogRef<ScheduleDetailsComponent>,
    private featureService: FeatureService,
    private userScheduleService: UserScheduleService
  ) {}

  ngOnInit(): void {
    this.schedule = this.data.schedule;
    this.reservations = this.data.reservations;
    this.user = this.data.user;
    this.hasReservation = this.data.hasReservation;
    if (this.schedule.Classroom.Id != undefined)
      this.featureService
        .GetFeaturesByClassroom(this.schedule.Classroom.Id)
        .subscribe((f) => (this.features = f));
  }
  addReservation() {
    if (this.user.Id != undefined && this.schedule.Id != undefined) {
      var us = { UserId: this.user.Id, ScheduleId: this.schedule.Id };
      this.userScheduleService.CreateUserSchedule(us).subscribe((val) => {
        if (val) {
          this.reservations++;
          this.hasReservation = true;
        }
      });
    }
  }
  removeReservation() {
    if (this.user.Id != undefined && this.schedule.Id != undefined) {
      var us = { UserId: this.user.Id, ScheduleId: this.schedule.Id };
      this.userScheduleService.DeleteUserSchedule(us).subscribe((val) => {
        if (val) {
          this.reservations--;
          this.hasReservation = false;
        }
      });
    }
  }
  close() {
    this.dialogRef.close();
  }
}
