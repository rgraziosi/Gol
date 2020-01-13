import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPassagerComponent } from './edit-passager.component';

describe('EditPassagerComponent', () => {
  let component: EditPassagerComponent;
  let fixture: ComponentFixture<EditPassagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPassagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPassagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
