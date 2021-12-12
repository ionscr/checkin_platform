import { TestBed } from '@angular/core/testing';

import { ClassroomfeatureService } from './classroomfeature.service';

describe('ClassroomfeatureService', () => {
  let service: ClassroomfeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClassroomfeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
