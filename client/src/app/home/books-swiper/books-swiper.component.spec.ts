import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooksSwiperComponent } from './books-swiper.component';

describe('BooksSwiperComponent', () => {
  let component: BooksSwiperComponent;
  let fixture: ComponentFixture<BooksSwiperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BooksSwiperComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BooksSwiperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
