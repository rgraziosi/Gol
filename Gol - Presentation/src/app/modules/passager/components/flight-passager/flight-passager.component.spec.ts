import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightPassagerComponent } from './flight-passager.component';

describe('FlightPassagerComponent', () => {
  let component: FlightPassagerComponent;
  let fixture: ComponentFixture<FlightPassagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightPassagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightPassagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
