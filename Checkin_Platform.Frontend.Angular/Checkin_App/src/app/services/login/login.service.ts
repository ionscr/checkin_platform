import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  logged: boolean = false;
  user: User;
  loggedChange: Subject<boolean> = new Subject<boolean>();
  constructor() {
    this.loggedChange.subscribe((value) => {
      this.logged = value;
    });
    if (localStorage.getItem('isLoggedIn') == 'true') {
      this.logged = true;
      var currentUser = localStorage.getItem('currentUser');
      if (currentUser != null) this.user = JSON.parse(currentUser);
    } else this.logged = false;
    this.loggedChange.next(this.logged);
  }

  logIn(user: User) {
    this.user = user;
    this.loggedChange.next(true);
    localStorage.setItem('isLoggedIn', this.logged.toString());
    localStorage.setItem('currentUser', JSON.stringify(this.user));
  }

  logOut() {
    this.user = <User>{};
    this.loggedChange.next(false);
    localStorage.setItem('isLoggedIn', this.logged.toString());
    localStorage.setItem('currentUser', '');
  }
  getLogged() {
    return this.logged;
  }
  getUser(): User {
    return this.user;
  }
}
