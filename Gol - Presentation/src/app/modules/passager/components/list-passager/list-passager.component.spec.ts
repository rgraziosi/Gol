import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPassagerComponent } from './list-passager.component';

describe('ListaAirplanesComponent', () => {
  let component: ListPassagerComponent;
  let fixture: ComponentFixture<ListPassagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPassagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPassagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
