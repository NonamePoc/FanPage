import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditChatComponent } from './edit-chat.component';

describe('EditChatComponent', () => {
  let component: EditChatComponent;
  let fixture: ComponentFixture<EditChatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditChatComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
