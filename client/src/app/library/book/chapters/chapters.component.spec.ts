import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChaptersComponent } from './chapters.component';

describe('ChaptersComponent', () => {
  let component: ChaptersComponent;
  let fixture: ComponentFixture<ChaptersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChaptersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChaptersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
