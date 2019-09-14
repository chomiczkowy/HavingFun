import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserRegisteredActivationRequiredComponent } from './user-registered-activation-required.component';

describe('UserRegisteredActivationRequiredComponent', () => {
  let component: UserRegisteredActivationRequiredComponent;
  let fixture: ComponentFixture<UserRegisteredActivationRequiredComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserRegisteredActivationRequiredComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserRegisteredActivationRequiredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
