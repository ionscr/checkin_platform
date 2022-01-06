import { formatDate } from '@angular/common';
import { Component, OnInit, Input, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Subject } from 'rxjs/internal/Subject';
import { ScheduleGroup } from 'src/app/models/schedule.model';
import { User } from 'src/app/models/user.model';
import { DateService } from 'src/app/services/date/date.service';
import { FilterService } from 'src/app/services/filter/filter.service';
import { LoginService } from 'src/app/services/login/login.service';
import { RefreshService } from 'src/app/services/refresh/refresh.service';
import { ScheduleService } from 'src/app/services/schedule/schedule.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-schedule-week',
  templateUrl: './schedule-week.component.html',
  styleUrls: ['./schedule-week.component.scss'],
})
export class ScheduleWeekComponent implements OnInit {
  @Input() weekNr = 0;
  filterEvent: Subject<void> = new Subject<void>();
  monday: Date = new Date();
  currentUser: User;
  week: string[] = [];
  teachers: User[] = [];
  weekSchedules: ScheduleGroup[] = [];
  filterByReservations: boolean = false;
  filterByTeacher: boolean = false;
  selectedTeacher: number = -1;
  filterForm = this.fb.group({
    Teacher: ['-1'],
  });
  constructor(
    private dateService: DateService,
    private refreshService: RefreshService,
    private scheduleService: ScheduleService,
    private fb: FormBuilder,
    private userService: UserService,
    private loginService: LoginService,
    private filterService: FilterService
  ) {}

  ngOnInit(): void {
    this.refreshService.assignRefresh(this.getWeekSchedules.bind(this));
  }
  ngOnChanges(changes: SimpleChanges) {
    this.generateDates();
    this.userService
      .GetUsersByRole('Teacher')
      .subscribe((users) => (this.teachers = users));
    this.getFilter();
    this.getWeekSchedules();
  }
  getFilter() {
    this.filterByReservations = this.filterService.getByReservations();
    var tch = this.filterService.getByTeacher();
    this.filterByTeacher = tch.byTeacher;
    this.selectedTeacher = tch.selectedTeacher;
    if (this.filterByTeacher)
      this.filterForm.patchValue({
        Teacher: this.selectedTeacher,
      });
  }
  getWeekSchedules() {
    this.currentUser = this.loginService.getUser();
    if (this.filterByReservations && this.currentUser.Id != undefined)
      this.scheduleService
        .GetWeekSchedulesByUser(
          formatDate(this.monday, 'yyyy-MM-dd', 'en-US') + 'T00:00:00',
          this.currentUser.Id
        )
        .subscribe((schedules) => {
          this.weekSchedules = schedules;
        });
    else
      this.scheduleService
        .GetSchedulesByWeek(
          formatDate(this.monday, 'yyyy-MM-dd', 'en-US') + 'T00:00:00'
        )
        .subscribe((schedules) => {
          this.weekSchedules = schedules;
        });
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
  onSelectTeacherToFilter($event: MatSelectChange) {
    if ($event.value != -1) this.filterService.setByTeacher(true, $event.value);
    else this.filterService.setByTeacher(false, -1);
    this.filterEvent.next();
  }
  onSlideToggle($event: MatSlideToggleChange) {
    if ($event.checked) this.filterService.setByReservations(true);
    else this.filterService.setByReservations(false);
    this.getFilter();
    this.getWeekSchedules();
  }
}
