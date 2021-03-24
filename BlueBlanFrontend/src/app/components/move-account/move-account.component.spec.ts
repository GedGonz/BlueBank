import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoveAccountComponent } from './move-account.component';

describe('MoveAccountComponent', () => {
  let component: MoveAccountComponent;
  let fixture: ComponentFixture<MoveAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoveAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoveAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
