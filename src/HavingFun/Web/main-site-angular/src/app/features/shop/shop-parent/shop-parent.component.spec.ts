import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopParentComponent } from './shop-parent.component';

describe('ShopParentComponent', () => {
  let component: ShopParentComponent;
  let fixture: ComponentFixture<ShopParentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShopParentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShopParentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
