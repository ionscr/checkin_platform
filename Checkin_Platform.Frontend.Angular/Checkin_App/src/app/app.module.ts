import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDividerModule } from '@angular/material/divider';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatChipsModule } from '@angular/material/chips';
import { DateAdapter, MatNativeDateModule } from '@angular/material/core';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HeaderComponent } from './components/header/header.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { ScheduleWeekComponent } from './components/schedule-week/schedule-week.component';
import { ScheduleDayComponent } from './components/schedule-day/schedule-day.component';
import { ScheduleItemComponent } from './components/schedule-item/schedule-item.component';
import { LoginComponent } from './components/dialogs/login/login.component';
import { ManageClassesComponent } from './components/dialogs/manage-classes/manage-classes.component';
import { ManageClassroomsComponent } from './components/dialogs/manage-classrooms/manage-classrooms.component';
import { ManageFeaturesComponent } from './components/dialogs/manage-features/manage-features.component';
import { ManageUsersComponent } from './components/dialogs/manage-users/manage-users.component';
import { ManageSchedulesComponent } from './components/dialogs/manage-schedules/manage-schedules.component';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { CustomDateAdapter } from './models/data_adapter.model';
import { ScheduleDetailsComponent } from './components/dialogs/schedule-details/schedule-details.component';
import { ScheduleEditComponent } from './components/dialogs/schedule-edit/schedule-edit.component';
import { ScheduleAddComponent } from './components/dialogs/schedule-add/schedule-add.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CalendarComponent,
    ScheduleWeekComponent,
    ScheduleDayComponent,
    ScheduleItemComponent,
    LoginComponent,
    ManageClassesComponent,
    ManageClassroomsComponent,
    ManageFeaturesComponent,
    ManageUsersComponent,
    ManageSchedulesComponent,
    ScheduleDetailsComponent,
    ScheduleEditComponent,
    ScheduleAddComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatDividerModule,
    MatStepperModule,
    MatChipsModule,
    MatTabsModule,
    MatIconModule,
    MatTableModule,
    MatCardModule,
    MatGridListModule,
    MatMenuModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSlideToggleModule,
    MatFormFieldModule,
    MatNativeDateModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    MatDatepickerModule,
    CustomDateAdapter,
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    { provide: DateAdapter, useClass: CustomDateAdapter },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
