import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsernameChangeModalComponent } from './username-change-modal.component';

describe('UsernameChangeModalComponent', () => {
  let component: UsernameChangeModalComponent;
  let fixture: ComponentFixture<UsernameChangeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UsernameChangeModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UsernameChangeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
