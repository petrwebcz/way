import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InviteUrlComponent } from './invite-url.component';

describe('InviteUrlComponent', () => {
  let component: InviteUrlComponent;
  let fixture: ComponentFixture<InviteUrlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InviteUrlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InviteUrlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
