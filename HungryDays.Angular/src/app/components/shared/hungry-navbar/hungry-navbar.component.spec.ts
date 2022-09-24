import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HungryNavbarComponent } from './hungry-navbar.component';

describe('HungryNavbarComponent', () => {
  let component: HungryNavbarComponent;
  let fixture: ComponentFixture<HungryNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HungryNavbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HungryNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
