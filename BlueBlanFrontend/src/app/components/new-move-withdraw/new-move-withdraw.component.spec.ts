import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewMoveWithdrawComponent } from './new-move-withdraw.component';

describe('NewMoveWithdrawComponent', () => {
  let component: NewMoveWithdrawComponent;
  let fixture: ComponentFixture<NewMoveWithdrawComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewMoveWithdrawComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewMoveWithdrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
