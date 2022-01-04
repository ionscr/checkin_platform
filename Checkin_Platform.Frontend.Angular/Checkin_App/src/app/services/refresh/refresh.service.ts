import { Injectable, EventEmitter, Output } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RefreshService {
  private refresh!: () => void;
  constructor() {}
  assignRefresh(fn: () => void) {
    this.refresh = fn;
  }
  callRefresh() {
    this.refresh();
  }
}
