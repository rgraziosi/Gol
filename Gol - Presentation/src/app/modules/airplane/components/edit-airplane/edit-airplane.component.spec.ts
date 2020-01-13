import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarAirplaneComponent } from './editar-airplane.component';

describe('EditarAirplaneComponent', () => {
  let component: EditarAirplaneComponent;
  let fixture: ComponentFixture<EditarAirplaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarAirplaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarAirplaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
