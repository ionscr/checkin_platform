import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Class } from 'src/app/models/class.model';
import { User } from 'src/app/models/user.model';
import { ClassService } from 'src/app/services/class/class.service';
import { UserService } from 'src/app/services/user/user.service';
import { Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
@Component({
  selector: 'app-manage-classes',
  templateUrl: './manage-classes.component.html',
  styleUrls: ['./manage-classes.component.scss'],
})
export class ManageClassesComponent implements OnInit {
  classes: Class[] = [];
  teachers: User[] = [];
  selectedClassToUpdateId: number = -1;
  isSelectedClassToUpdate: boolean = false;
  selectedClassToDeleteId: number = -1;
  isSelectedClassToDelete: boolean = false;
  updateTeacher?: User;
  newClassForm = this.fb.group({
    Name: ['', Validators.required],
    UserId: ['', Validators.required],
    Year: ['', Validators.pattern],
    Section: ['', Validators.required],
  });
  updateClassForm = this.fb.group({
    Id: [''],
    Name: ['', Validators.required],
    Teacher: ['', Validators.required],
    Year: ['', Validators.pattern],
    Section: ['', Validators.required],
  });
  deleteClassForm = this.fb.group({
    Id: [''],
  });
  constructor(
    private classService: ClassService,
    private userService: UserService,
    private dialogRef: MatDialogRef<ManageClassesComponent>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getClasses();
    this.getTeachers();
  }
  getClasses() {
    this.classService
      .GetClasses()
      .subscribe((classes) => (this.classes = classes));
  }
  getTeachers() {
    this.userService
      .GetUsersByRole('Teacher')
      .subscribe((teachers) => (this.teachers = teachers));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectTeacherToUpdate($event: MatSelectChange) {
    this.updateTeacher = this.teachers.find((t) => t.Id == $event.value);
  }
  onSelectClassToUpdate($event: MatSelectChange) {
    this.isSelectedClassToUpdate = true;
    this.selectedClassToUpdateId = $event.value.Id;
    this.updateClassForm.patchValue({
      Name: $event.value.Name,
      Teacher: $event.value.Teacher.Id,
      Year: $event.value.Year,
      Section: $event.value.Section,
    });
    this.updateTeacher = $event.value.Teacher;
  }
  onSelectClassToDelete($event: MatSelectChange) {
    this.isSelectedClassToDelete = true;
    this.selectedClassToDeleteId = $event.value.Id;
  }
  onSubmitAdd() {
    this.classService.CreateClass(this.newClassForm.value).subscribe((val) => {
      if (val) this.newClassForm.reset();
      this.getClasses();
      this.getTeachers();
    });
  }
  onSubmitUpdate() {
    if (this.updateTeacher != undefined) {
      this.updateClassForm.patchValue({
        Id: this.selectedClassToUpdateId,
        Teacher: this.updateTeacher,
      });
      this.classService
        .UpdateClass(this.updateClassForm.value)
        .subscribe((val) => {
          if (val) this.updateClassForm.reset();
          this.getClasses();
          this.getTeachers();
        });
    }
  }
  onSubmitDelete() {
    this.classService
      .DeleteClass(this.selectedClassToDeleteId)
      .subscribe((val) => {
        if (val) this.deleteClassForm.reset();
        this.getClasses();
        this.getTeachers();
      });
  }
  onChange() {
    this.isSelectedClassToUpdate = false;
    this.newClassForm.reset();
    this.updateClassForm.reset();
    this.deleteClassForm.reset();
  }
}
