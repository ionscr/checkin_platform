import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FilterService {
  byReservations: boolean = false;
  byTeacher: boolean = false;
  selectedTeacher: number = -1;
  constructor() {}

  setByReservations(value: boolean) {
    this.byReservations = value;
  }
  setByTeacher(value: boolean, teacher: number) {
    this.byTeacher = value;
    this.selectedTeacher = teacher;
  }
  getByReservations(): boolean {
    return this.byReservations;
  }
  getByTeacher() {
    var val = {
      byTeacher: this.byTeacher,
      selectedTeacher: this.selectedTeacher,
    };
    return val;
  }
}
