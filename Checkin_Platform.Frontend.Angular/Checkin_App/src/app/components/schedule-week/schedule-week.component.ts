import { formatDate } from '@angular/common';
import { Component, OnInit, Input, Output, SimpleChanges } from '@angular/core';
import { DateService } from 'src/app/services/date/date.service';
import { ScheduleService } from 'src/app/services/schedule/schedule.service';

@Component({
  selector: 'app-schedule-week',
  templateUrl: './schedule-week.component.html',
  styleUrls: ['./schedule-week.component.css'],
})
export class ScheduleWeekComponent implements OnInit {
  @Input() weekNr = 0;
  monday: Date = new Date();
  week: string[] = [];
  constructor(
    private dateService: DateService,
    private scheduleService: ScheduleService
  ) {}

  ngOnInit(): void {
    this.generateDates();
  }
  ngOnChanges(changes: SimpleChanges) {
    this.monday = this.generateMonday();
    this.week = this.generateWeek();
  }
  generateDates() {
    this.monday = this.generateMonday();
    this.week = this.generateWeek();
  }
  generateMonday(): Date {
    return this.dateService.getMonday(this.weekNr);
  }
  generateWeek(): string[] {
    var week: string[] = [];
    for (var i = 0; i < 5; i++)
      week.push(
        formatDate(
          this.dateService.addDays(this.monday, i),
          'yyyy-MM-dd',
          'en-US'
        )
      );
    return week;
  }
}
