import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageFeaturesComponent } from './manage-features.component';

describe('ManageFeaturesComponent', () => {
  let component: ManageFeaturesComponent;
  let fixture: ComponentFixture<ManageFeaturesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageFeaturesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageFeaturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
