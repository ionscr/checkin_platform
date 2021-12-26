import { Component, OnInit } from '@angular/core';
import { formatDate } from '@angular/common';
import { DateService } from 'src/app/services/date/date.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
})
export class CalendarComponent implements OnInit {
  weekNr: number = 0;
  monday: string = '';
  friday: string = '';
  logged: boolean = false;
  constructor(private dateService: DateService) {}

  ngOnInit(): void {
    this.monday = this.formatMonday();
    this.friday = this.formatFriday();
  }
  formatMonday(): string {
    return formatDate(
      this.dateService.getMonday(this.weekNr),
      'dd.MM',
      'en-US'
    );
  }
  formatFriday(): string {
    return formatDate(
      this.dateService.getFriday(this.weekNr),
      'dd.MM',
      'en-US'
    );
  }
  onForward() {
    this.weekNr++;
    this.monday = this.formatMonday();
    this.friday = this.formatFriday();
  }
  onBackward() {
    this.weekNr--;
    this.monday = this.formatMonday();
    this.friday = this.formatFriday();
  }
}
