import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoriMoveAccountComponent } from './histori-move-account.component';

describe('HistoriMoveAccountComponent', () => {
  let component: HistoriMoveAccountComponent;
  let fixture: ComponentFixture<HistoriMoveAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoriMoveAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoriMoveAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
