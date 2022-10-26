import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HungryListComponent } from './hungry-list.component';

describe('HungryListComponent', () => {
  let component: HungryListComponent;
  let fixture: ComponentFixture<HungryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HungryListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HungryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
