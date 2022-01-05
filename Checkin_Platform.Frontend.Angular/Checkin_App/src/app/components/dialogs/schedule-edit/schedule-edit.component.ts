import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { Class } from 'src/app/models/class.model';
import { Classroom } from 'src/app/models/classroom.model';
import { Schedule } from 'src/app/models/schedule.model';
import { ClassService } from 'src/app/services/class/class.service';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { ScheduleService } from 'src/app/services/schedule/schedule.service';
import { formatDate } from '@angular/common';
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models/user.model';
import { UserScheduleService } from 'src/app/services/userschedule/userschedule.service';
export interface DialogData {
  schedule: Schedule;
}
@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.css'],
})
export class ScheduleEditComponent implements OnInit {
  schedule: Schedule;
  classes: Class[] = [];
  classrooms: Classroom[] = [];
  currentUsers: User[] = [];
  otherUsers: User[] = [];
  classroomCapacity: number = 0;
  currentCapacity: number = 0;
  selectedClassForUpdate?: Class;
  selectedClassroomForUpdate?: Classroom;
  updateScheduleForm = this.fb.group({
    Id: [''],
    Date: ['', Validators.required],
    Time: ['', Validators.required],
    Classroom: ['', Validators.required],
    Class: ['', Validators.pattern],
  });
  removeReservationsForm = this.fb.group({
    ScheduleId: [''],
    UserId: ['', Validators.required],
  });
  addReservationsForm = this.fb.group({
    ScheduleId: [''],
    UserId: ['', Validators.required],
  });
  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDay();
    return day !== 0 && day !== 6;
  };
  constructor(
    private scheduleService: ScheduleService,
    private classService: ClassService,
    private classroomService: ClassroomService,
    private userService: UserService,
    private userScheduleService: UserScheduleService,
    private dialogRef: MatDialogRef<ScheduleEditComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  ngOnInit(): void {
    this.schedule = this.data.schedule;
    this.setScheduleData();
    this.getClasses();
    this.getClassrooms();
  }

  getClasses() {
    this.classService
      .GetClasses()
      .subscribe((classes) => (this.classes = classes));
  }
  getClassrooms() {
    this.classroomService
      .GetClassrooms()
      .subscribe((classrooms) => (this.classrooms = classrooms));
  }
  getReservations(scheduleId: number) {
    this.userService.GetUsersBySchedule(scheduleId).subscribe((users) => {
      this.currentUsers = users;
      this.currentCapacity = users.length;
    });
    this.userService
      .GetOtherUsersBySchedule(scheduleId)
      .subscribe((users) => (this.otherUsers = users));
  }
  close() {
    this.dialogRef.close();
  }
  setScheduleData() {
    this.updateScheduleForm.patchValue({
      Id: this.schedule.Id,
      Date: this.schedule.DateTime,
      Time: this.schedule.DateTime.slice(11, 16),
      Classroom: this.schedule.Classroom.Id,
      Class: this.schedule.Class.Id,
    });
    this.selectedClassForUpdate = this.schedule.Class;
    this.selectedClassroomForUpdate = this.schedule.Classroom;
    if (this.schedule.Id != undefined) this.getReservations(this.schedule.Id);
    this.classroomCapacity = this.schedule.Classroom.Capacity;
  }
  onSelectClassToUpdate($event: MatSelectChange) {
    this.selectedClassForUpdate = this.classes.find(
      (c) => c.Id == $event.value
    );
  }
  onSelectClassroomToUpdate($event: MatSelectChange) {
    this.selectedClassroomForUpdate = this.classrooms.find(
      (c) => c.Id == $event.value
    );
  }
  onSubmitUpdate() {
    if (
      this.selectedClassForUpdate != undefined &&
      this.selectedClassroomForUpdate != undefined
    ) {
      var schedule = {
        Id: this.schedule.Id,
        DateTime:
          formatDate(
            this.updateScheduleForm.value.Date,
            'yyyy-MM-dd',
            'en-US'
          ) +
          'T' +
          this.updateScheduleForm.value.Time +
          ':00',
        Classroom: this.selectedClassroomForUpdate,
        Class: this.selectedClassForUpdate,
      };
      this.scheduleService.UpdateSchedule(schedule).subscribe((val) => {
        if (val) this.close();
      });
    }
  }
  onSubmitDelete() {
    if (this.schedule.Id != undefined)
      this.scheduleService.DeleteSchedule(this.schedule.Id).subscribe((val) => {
        if (val) this.close();
      });
  }
  onRemoveReservation() {
    if (this.schedule.Id != undefined) {
      var usDto = {
        UserId: this.removeReservationsForm.value.UserId,
        ScheduleId: this.schedule.Id,
      };
      this.userScheduleService.DeleteUserSchedule(usDto).subscribe((val) => {
        if (val) this.removeReservationsForm.reset();
        if (this.schedule.Id != undefined)
          this.getReservations(this.schedule.Id);
      });
    }
  }
  onAddReservation() {
    if (this.schedule.Id != undefined) {
      var usDto = {
        UserId: this.addReservationsForm.value.UserId,
        ScheduleId: this.schedule.Id,
      };
      this.userScheduleService.CreateUserSchedule(usDto).subscribe((val) => {
        if (val) this.addReservationsForm.reset();
        if (this.schedule.Id != undefined)
          this.getReservations(this.schedule.Id);
      });
    }
  }
}
