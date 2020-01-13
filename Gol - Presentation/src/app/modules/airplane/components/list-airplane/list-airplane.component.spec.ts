import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAirplanesComponent } from './lista-airplanes.component';

describe('ListaAirplanesComponent', () => {
  let component: ListaAirplanesComponent;
  let fixture: ComponentFixture<ListaAirplanesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAirplanesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAirplanesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
