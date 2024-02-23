import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestorePasswordModalComponent } from './restore-password-modal.component';

describe('RestorePasswordModalComponent', () => {
  let component: RestorePasswordModalComponent;
  let fixture: ComponentFixture<RestorePasswordModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RestorePasswordModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RestorePasswordModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
