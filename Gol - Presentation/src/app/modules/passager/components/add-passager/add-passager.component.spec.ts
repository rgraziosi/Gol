import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPassagerComponent } from './add-passager.component';

describe('AdicionarPassagerComponent', () => {
  let component: AddPassagerComponent;
  let fixture: ComponentFixture<AddPassagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPassagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPassagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
