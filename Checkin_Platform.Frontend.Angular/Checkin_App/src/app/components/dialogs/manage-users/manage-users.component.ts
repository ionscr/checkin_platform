import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.scss'],
})
export class ManageUsersComponent implements OnInit {
  users: User[] = [];
  selectedUserToUpdateId: number = -1;
  isSelectedUserToUpdate: boolean = false;
  selectedUserToDeleteId: number = -1;
  isSelectedUserToDelete: boolean = false;
  selectedRole: String = '';
  newUserForm = this.fb.group({
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    Email: ['', Validators.required],
    Password: ['', Validators.required],
    Role: ['', Validators.required],
    Department: [''],
    Year: [''],
    Group: [''],
  });
  updateUserForm = this.fb.group({
    Id: [''],
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    Email: ['', Validators.required],
    Password: [''],
    Role: ['', Validators.required],
    Department: [''],
    Year: [''],
    Group: [''],
  });
  deleteUserForm = this.fb.group({
    Id: [''],
  });

  constructor(
    private userService: UserService,
    private dialogRef: MatDialogRef<ManageUsersComponent>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers() {
    this.userService.GetUsers().subscribe((users) => (this.users = users));
  }
  close() {
    this.dialogRef.close();
  }
  onSelectUserToUpdate($event: MatSelectChange) {
    this.isSelectedUserToUpdate = true;
    this.selectedUserToUpdateId = $event.value.Id;
    this.selectedRole = $event.value.Role;
    this.updateUserForm.patchValue({
      FirstName: $event.value.FirstName,
      LastName: $event.value.LastName,
      Email: $event.value.Email,
      Role: $event.value.Role,
      Department: $event.value.Department,
      Year: $event.value.Year,
      Group: $event.value.Group,
    });
  }
  onSelectUserRole($event: MatSelectChange) {
    this.selectedRole = $event.value;
    this.updateUserForm.patchValue({
      Department: undefined,
      Year: undefined,
      Group: undefined,
    });
    this.newUserForm.patchValue({
      Department: undefined,
      Year: undefined,
      Group: undefined,
    });
  }
  onSelectUserToDelete($event: MatSelectChange) {
    this.isSelectedUserToDelete = true;
    this.selectedUserToDeleteId = $event.value.Id;
  }
  onSubmitAdd() {
    this.userService.CreateUser(this.newUserForm.value).subscribe((val) => {
      if (val) this.newUserForm.reset();
      this.getUsers();
    });
  }
  onSubmitUpdate() {
    if (this.updateUserForm.value.Role == 'Teacher') {
      this.updateUserForm.patchValue({
        Group: undefined,
        Year: undefined,
      });
    }
    if (this.updateUserForm.value.Role == 'Student') {
      this.updateUserForm.patchValue({
        Department: undefined,
      });
    }
    this.updateUserForm.patchValue({
      Id: this.selectedUserToUpdateId,
    });
    this.userService.UpdateUser(this.updateUserForm.value).subscribe((val) => {
      if (val) this.updateUserForm.reset();
      this.getUsers();
    });
  }
  onSubmitDelete() {
    this.userService
      .DeleteUser(this.selectedUserToDeleteId)
      .subscribe((val) => {
        if (val) this.deleteUserForm.reset();
        this.getUsers();
      });
  }
  onChange() {
    this.isSelectedUserToUpdate = false;
    this.isSelectedUserToDelete = false;
    this.selectedRole = '';
    this.newUserForm.reset();
    this.updateUserForm.reset();
    this.deleteUserForm.reset();
  }
}
