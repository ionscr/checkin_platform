import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
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
@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.css'],
})
export class ScheduleEditComponent implements OnInit {
  schedules: Schedule[] = [];
  classes: Class[] = [];
  classrooms: Classroom[] = [];
  users: User[] = [];
  otherUsers: User[] = [];
  classroomCapacity: number = 0;
  currentCapacity: number = 0;
  selectedScheduleToUpdateId: number = -1;
  isSelectedScheduleToUpdate: boolean = false;
  selectedClassForUpdate?: Class;
  selectedClassroomForUpdate?: Classroom;
  selectedScheduleToDeleteId: number = -1;
  isSelectedScheduleToDelete: boolean = false;
  selectedScheduleToManageId: number = -1;
  isSelectedScheduleToManage: boolean = false;
  updateScheduleForm = this.fb.group({
    Id: [''],
    Date: ['', Validators.required],
    Time: ['', Validators.required],
    Classroom: ['', Validators.required],
    Class: ['', Validators.pattern],
  });
  deleteScheduleForm = this.fb.group({
    Id: [''],
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
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getSchedules();
    this.getClasses();
    this.getClassrooms();
  }
  getSchedules() {
    this.scheduleService
      .GetSchedules()
      .subscribe((schedules) => (this.schedules = schedules));
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
      this.users = users;
      this.currentCapacity = users.length;
    });
    this.userService
      .GetOtherUsersBySchedule(scheduleId)
      .subscribe((users) => (this.otherUsers = users));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectScheduleToUpdate($event: MatSelectChange) {
    this.isSelectedScheduleToUpdate = true;
    this.selectedScheduleToUpdateId = $event.value.Id;
    this.updateScheduleForm.patchValue({
      Date: $event.value.DateTime,
      Time: $event.value.DateTime.slice(11, 16),
      Classroom: $event.value.Classroom.Id,
      Class: $event.value.Class.Id,
    });
    this.selectedClassForUpdate = $event.value.Class;
    this.selectedClassroomForUpdate = $event.value.Classroom;
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
  onSelectScheduleToDelete($event: MatSelectChange) {
    this.isSelectedScheduleToDelete = true;
    this.selectedScheduleToDeleteId = $event.value.Id;
  }
  onSelectScheduleToManage($event: MatSelectChange) {
    this.isSelectedScheduleToManage = true;
    this.selectedScheduleToManageId = $event.value.Id;
    this.getReservations(this.selectedScheduleToManageId);
    this.classroomCapacity = $event.value.Classroom.Capacity;
  }
  onSubmitUpdate() {
    console.log(this.selectedClassForUpdate);
    console.log(this.selectedClassroomForUpdate);
    if (
      this.selectedClassForUpdate != undefined &&
      this.selectedClassroomForUpdate != undefined
    ) {
      var schedule = {
        Id: this.selectedScheduleToUpdateId,
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
        if (val) this.updateScheduleForm.reset();
        this.getSchedules();
      });
    }
  }
  onSubmitDelete() {
    this.scheduleService
      .DeleteSchedule(this.selectedScheduleToDeleteId)
      .subscribe((val) => {
        if (val) this.deleteScheduleForm.reset();
        this.getSchedules();
      });
  }
  onRemoveReservation() {
    const usDto = {
      UserId: this.removeReservationsForm.value.UserId,
      ScheduleId: this.selectedScheduleToManageId,
    };
    this.userScheduleService.DeleteUserSchedule(usDto).subscribe((val) => {
      if (val) this.removeReservationsForm.reset();
      this.getReservations(this.selectedScheduleToManageId);
    });
  }
  onAddReservation() {
    const usDto = {
      UserId: this.addReservationsForm.value.UserId,
      ScheduleId: this.selectedScheduleToManageId,
    };
    this.userScheduleService.CreateUserSchedule(usDto).subscribe((val) => {
      if (val) this.addReservationsForm.reset();
      this.getReservations(this.selectedScheduleToManageId);
    });
  }
  onChange() {
    this.isSelectedScheduleToUpdate = false;
    this.isSelectedScheduleToDelete = false;
    this.isSelectedScheduleToManage = false;
    this.updateScheduleForm.reset();
    this.deleteScheduleForm.reset();
  }
}
