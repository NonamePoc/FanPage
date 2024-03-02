import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanModalComponent } from './ban-modal.component';

describe('BanModalComponent', () => {
  let component: BanModalComponent;
  let fixture: ComponentFixture<BanModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BanModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BanModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
