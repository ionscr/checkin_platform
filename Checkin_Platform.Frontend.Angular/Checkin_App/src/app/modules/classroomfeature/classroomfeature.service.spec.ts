import { TestBed } from '@angular/core/testing';
import { ClassroomFeatureService } from './classroomfeature.service';


describe('ClassroomfeatureService', () => {
  let service: ClassroomFeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClassroomFeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
