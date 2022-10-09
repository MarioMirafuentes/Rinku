import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormMovimientosComponent } from './form-movimientos.component';

describe('FormMovimientosComponent', () => {
  let component: FormMovimientosComponent;
  let fixture: ComponentFixture<FormMovimientosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormMovimientosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormMovimientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
