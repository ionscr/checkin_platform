import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { Classroom } from 'src/app/models/classroom.model';
import { Feature } from 'src/app/models/feature.model';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { ClassroomFeatureService } from 'src/app/services/classroomfeature/classroomfeature.service';
import { FeatureService } from 'src/app/services/feature/feature.service';

@Component({
  selector: 'app-manage-classrooms',
  templateUrl: './manage-classrooms.component.html',
  styleUrls: ['./manage-classrooms.component.scss'],
})
export class ManageClassroomsComponent implements OnInit {
  classrooms: Classroom[] = [];
  otherFeatures: Feature[] = [];
  currentFeatures: Feature[] = [];
  selectedClassroomToUpdateId: number = -1;
  isSelectedClassroomToUpdate: boolean = false;
  selectedClassroomToDeleteId: number = -1;
  isSelectedClassroomToDelete: boolean = false;
  selectedClassroomToManageId: number = -1;
  isSelectedClassroomToManage: boolean = false;
  newClassroomForm = this.fb.group({
    Name: ['', Validators.required],
    Location: ['', Validators.required],
    Capacity: ['', Validators.pattern],
  });
  updateClassroomForm = this.fb.group({
    Id: [''],
    Name: ['', Validators.required],
    Location: ['', Validators.required],
    Capacity: ['', Validators.pattern],
  });
  deleteClassroomForm = this.fb.group({
    Id: [''],
  });
  removeFeaturesForm = this.fb.group({
    Id: [''],
  });
  addFeaturesForm = this.fb.group({
    Id: [''],
  });
  constructor(
    private classroomService: ClassroomService,
    private featureService: FeatureService,
    private classromFeatureService: ClassroomFeatureService,
    private dialogRef: MatDialogRef<ManageClassroomsComponent>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getClassrooms();
  }
  getClassrooms() {
    this.classroomService
      .GetClassrooms()
      .subscribe((classrooms) => (this.classrooms = classrooms));
  }
  getOtherFeatures(id: number) {
    this.featureService
      .GetOtherFeaturesByClassroom(id)
      .subscribe((otherFeatures) => (this.otherFeatures = otherFeatures));
  }
  getCurrentFeatures(id: number) {
    this.featureService
      .GetFeaturesByClassroom(id)
      .subscribe((currentFeatures) => (this.currentFeatures = currentFeatures));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectClassroomToUpdate($event: MatSelectChange) {
    this.isSelectedClassroomToUpdate = true;
    this.selectedClassroomToUpdateId = $event.value.Id;
    this.updateClassroomForm.patchValue({
      Name: $event.value.Name,
      Location: $event.value.Location,
      Capacity: $event.value.Capacity,
    });
  }
  onSelectClassroomToDelete($event: MatSelectChange) {
    this.isSelectedClassroomToDelete = true;
    this.selectedClassroomToDeleteId = $event.value.Id;
  }
  onSelectClassroomToManage($event: MatSelectChange) {
    this.isSelectedClassroomToManage = true;
    this.selectedClassroomToManageId = $event.value.Id;
    this.getCurrentFeatures(this.selectedClassroomToManageId);
    this.getOtherFeatures(this.selectedClassroomToManageId);
  }
  onSubmitAdd() {
    this.classroomService
      .CreateClassroom(this.newClassroomForm.value)
      .subscribe((val) => {
        if (val) this.newClassroomForm.reset();
        this.getClassrooms();
      });
  }
  onSubmitUpdate() {
    this.updateClassroomForm.patchValue({
      Id: this.selectedClassroomToUpdateId,
    });
    this.classroomService
      .UpdateClassroom(this.updateClassroomForm.value)
      .subscribe((val) => {
        if (val) this.updateClassroomForm.reset();
        this.getClassrooms();
      });
  }
  onSubmitDelete() {
    this.classroomService
      .DeleteClassroom(this.selectedClassroomToDeleteId)
      .subscribe((val) => {
        if (val) this.deleteClassroomForm.reset();
        this.getClassrooms();
      });
  }
  onRemoveFeature() {
    var fid = this.removeFeaturesForm.value;
    var cf = {
      FeatureId: fid.Id,
      ClassroomId: this.selectedClassroomToManageId,
    };
    this.classromFeatureService.DeleteClassroomFeature(cf).subscribe((val) => {
      if (val) this.removeFeaturesForm.reset();
      this.getCurrentFeatures(this.selectedClassroomToManageId);
      this.getOtherFeatures(this.selectedClassroomToManageId);
    });
  }
  onAddFeature() {
    var fid = this.addFeaturesForm.value;
    var cf = {
      FeatureId: fid.Id,
      ClassroomId: this.selectedClassroomToManageId,
    };
    this.classromFeatureService.CreateClassroomFeature(cf).subscribe((val) => {
      if (val) this.addFeaturesForm.reset();
      this.getCurrentFeatures(this.selectedClassroomToManageId);
      this.getOtherFeatures(this.selectedClassroomToManageId);
    });
  }
  onChange() {
    this.isSelectedClassroomToUpdate = false;
    this.isSelectedClassroomToDelete = false;
    this.isSelectedClassroomToManage = false;
    this.newClassroomForm.reset();
    this.updateClassroomForm.reset();
    this.deleteClassroomForm.reset();
  }
}
