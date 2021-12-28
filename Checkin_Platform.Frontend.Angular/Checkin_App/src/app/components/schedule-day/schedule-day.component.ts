import { Component, Input, OnInit } from '@angular/core';
import { Schedule } from 'src/app/models/schedule.model';

@Component({
  selector: 'app-schedule-day',
  templateUrl: './schedule-day.component.html',
  styleUrls: ['./schedule-day.component.css'],
})
export class ScheduleDayComponent implements OnInit {
  @Input() schedules: Schedule[] = [];
  constructor() {}

  ngOnInit(): void {}
}
