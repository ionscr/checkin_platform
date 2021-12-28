import { formatDate } from '@angular/common';
import { Component, OnInit, Input, Output, SimpleChanges } from '@angular/core';
import { Schedule } from 'src/app/models/schedule.model';
import { ScheduleGroup } from 'src/app/models/schedule_group.model';
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
  weekSchedules: ScheduleGroup[] = [];
  constructor(
    private dateService: DateService,
    private scheduleService: ScheduleService
  ) {}

  ngOnInit(): void {}
  ngOnChanges(changes: SimpleChanges) {
    this.generateDates();
    this.getWeekSchedules();
  }
  getWeekSchedules() {
    this.scheduleService
      .GetSchedulesByWeek(
        formatDate(this.monday, 'yyyy-MM-dd', 'en-US') + 'T00:00:00'
      )
      .subscribe((schedules) => (this.weekSchedules = schedules));
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
