import { Component, Input, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Schedule } from 'src/app/models/schedule.model';
import { FilterService } from 'src/app/services/filter/filter.service';

@Component({
  selector: 'app-schedule-day',
  templateUrl: './schedule-day.component.html',
  styleUrls: ['./schedule-day.component.css'],
})
export class ScheduleDayComponent implements OnInit {
  @Input() schedules: Schedule[] = [];
  @Input() events: Observable<void>;
  filteredSchedules: Schedule[] = [];
  filterByReservations: boolean = false;
  filterByTeacher: boolean = false;
  filterTeacher: number = -1;
  private eventsSubscription: Subscription;
  constructor(private filterService: FilterService) {}

  ngOnInit(): void {
    this.eventsSubscription = this.events.subscribe(() => this.filter());
    this.filter();
  }
  filter() {
    this.filterByReservations = this.filterService.getByReservations();
    var tch = this.filterService.getByTeacher();
    this.filterByTeacher = tch.byTeacher;
    this.filterTeacher = tch.selectedTeacher;
    this.filteredSchedules = this.schedules;
    if (this.filterByTeacher) {
      this.filteredSchedules = this.schedules.filter(
        (sc) => sc.Class.Teacher.Id == this.filterTeacher
      );
    }
  }

  ngOnDestroy() {
    this.eventsSubscription.unsubscribe();
  }
}
