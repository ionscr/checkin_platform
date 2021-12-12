import { TestBed } from '@angular/core/testing';

import { UserscheduleService } from './userschedule.service';

describe('UserscheduleService', () => {
  let service: UserscheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserscheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
