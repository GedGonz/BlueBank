import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewMoveConsignComponent } from './new-move-consign.component';

describe('NewMoveConsignComponent', () => {
  let component: NewMoveConsignComponent;
  let fixture: ComponentFixture<NewMoveConsignComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewMoveConsignComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewMoveConsignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
