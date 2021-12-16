import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import { Class } from 'src/app/modules/class/class.model';

import * as classActions from '../../modules/class/state/class.actions';
import * as classReducer from '../../modules/class/state/class.reducer';
import * as classSelector from '../../modules/class/state/class.selector';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  title: String = 'Check-in Platform';
  classes$?: Observable<Class[]>;
  error$?: Observable<String>;
  constructor(private store: Store<classReducer.AppState>) {}

  ngOnInit(): void {
    //this.store.dispatch(new classActions.LoadClasses());
    //this.classes$ = this.store.pipe(select(classSelector.getClasses));
    //this.error$ = this.store.pipe(select(classSelector.getError));
  }
}
