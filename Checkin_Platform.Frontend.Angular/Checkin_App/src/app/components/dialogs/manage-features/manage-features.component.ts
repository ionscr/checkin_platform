import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { Feature } from 'src/app/models/feature.model';
import { FeatureService } from 'src/app/services/feature/feature.service';

@Component({
  selector: 'app-manage-features',
  templateUrl: './manage-features.component.html',
  styleUrls: ['./manage-features.component.scss'],
})
export class ManageFeaturesComponent implements OnInit {
  features: Feature[] = [];
  selectedFeatureToUpdateId: number = -1;
  isSelectedFeatureToUpdate: boolean = false;
  selectedFeatureToDeleteId: number = -1;
  isSelectedFeatureToDelete: boolean = false;
  newFeatureForm = this.fb.group({
    Name: ['', Validators.required],
  });
  updateFeatureForm = this.fb.group({
    Id: [''],
    Name: ['', Validators.required],
  });
  deleteFeatureForm = this.fb.group({
    Id: [''],
  });
  constructor(
    private featureService: FeatureService,
    private dialogRef: MatDialogRef<ManageFeaturesComponent>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getFeatures();
  }
  getFeatures() {
    this.featureService
      .GetFeatures()
      .subscribe((features) => (this.features = features));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectFeatureToUpdate($event: MatSelectChange) {
    this.isSelectedFeatureToUpdate = true;
    this.selectedFeatureToUpdateId = $event.value.Id;
    this.updateFeatureForm.patchValue({
      Name: $event.value.Name,
    });
  }
  onSelectFeatureToDelete($event: MatSelectChange) {
    this.isSelectedFeatureToDelete = true;
    this.selectedFeatureToDeleteId = $event.value.Id;
  }
  onSubmitAdd() {
    this.featureService
      .CreateFeature(this.newFeatureForm.value)
      .subscribe((val) => {
        if (val) this.newFeatureForm.reset();
        this.getFeatures();
      });
  }
  onSubmitUpdate() {
    this.updateFeatureForm.patchValue({
      Id: this.selectedFeatureToUpdateId,
    });
    this.featureService
      .UpdateFeature(this.updateFeatureForm.value)
      .subscribe((val) => {
        if (val) this.updateFeatureForm.reset();
        this.getFeatures();
      });
  }
  onSubmitDelete() {
    this.featureService
      .DeleteFeature(this.selectedFeatureToDeleteId)
      .subscribe((val) => {
        if (val) this.deleteFeatureForm.reset();
        this.getFeatures();
      });
  }
  onChange() {
    this.isSelectedFeatureToUpdate = false;
    this.newFeatureForm.reset();
    this.updateFeatureForm.reset();
    this.deleteFeatureForm.reset();
  }
}
