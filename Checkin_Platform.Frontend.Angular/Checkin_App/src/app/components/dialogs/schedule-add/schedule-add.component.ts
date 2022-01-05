import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { Class } from 'src/app/models/class.model';
import { Classroom } from 'src/app/models/classroom.model';
import { User } from 'src/app/models/user.model';
import { ClassService } from 'src/app/services/class/class.service';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { LoginService } from 'src/app/services/login/login.service';
import { ScheduleService } from 'src/app/services/schedule/schedule.service';

@Component({
  selector: 'app-schedule-add',
  templateUrl: './schedule-add.component.html',
  styleUrls: ['./schedule-add.component.css'],
})
export class ScheduleAddComponent implements OnInit {
  currentUser: User;
  classes: Class[] = [];
  classrooms: Classroom[] = [];
  selectedClassForAdd?: Class;
  selectedClassroomForAdd?: Classroom;
  addScheduleForm = this.fb.group({
    Date: ['', Validators.required],
    Time: ['', Validators.required],
    Classroom: ['', Validators.required],
    Class: ['', Validators.pattern],
  });
  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDay();
    return day !== 0 && day !== 6;
  };
  constructor(
    private scheduleService: ScheduleService,
    private loginService: LoginService,
    private classService: ClassService,
    private classroomService: ClassroomService,
    private dialogRef: MatDialogRef<ScheduleAddComponent>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.currentUser = this.loginService.getUser();
    this.getClasses();
    this.getClassrooms();
  }

  getClasses() {
    if (this.currentUser.Id != undefined)
      this.classService
        .GetClassesByTeacher(this.currentUser.Id)
        .subscribe((classes) => (this.classes = classes));
  }
  getClassrooms() {
    this.classroomService
      .GetClassrooms()
      .subscribe((classrooms) => (this.classrooms = classrooms));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectClassToAdd($event: MatSelectChange) {
    this.selectedClassForAdd = this.classes.find((c) => c.Id == $event.value);
  }
  onSelectClassroomToAdd($event: MatSelectChange) {
    this.selectedClassroomForAdd = this.classrooms.find(
      (c) => c.Id == $event.value
    );
  }
  onSubmitAdd() {
    if (
      this.selectedClassForAdd != undefined &&
      this.selectedClassForAdd.Id != undefined &&
      this.selectedClassroomForAdd != undefined &&
      this.selectedClassroomForAdd.Id != undefined
    ) {
      var schedule = {
        DateTime:
          formatDate(this.addScheduleForm.value.Date, 'yyyy-MM-dd', 'en-US') +
          'T' +
          this.addScheduleForm.value.Time +
          ':00',
        ClassroomId: this.selectedClassroomForAdd.Id,
        ClassId: this.selectedClassForAdd.Id,
      };
      this.scheduleService.CreateSchedule(schedule).subscribe((val) => {
        if (val) this.close();
      });
    }
  }
}
