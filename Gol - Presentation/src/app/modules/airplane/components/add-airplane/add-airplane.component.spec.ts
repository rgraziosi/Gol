import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarAirplaneComponent } from './adicionar-airplane.component';

describe('AdicionarAirplaneComponent', () => {
  let component: AdicionarAirplaneComponent;
  let fixture: ComponentFixture<AdicionarAirplaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarAirplaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarAirplaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
