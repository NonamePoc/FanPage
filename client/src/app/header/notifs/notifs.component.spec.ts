import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifsComponent } from './notifs.component';

describe('NotifsComponent', () => {
  let component: NotifsComponent;
  let fixture: ComponentFixture<NotifsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotifsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NotifsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
