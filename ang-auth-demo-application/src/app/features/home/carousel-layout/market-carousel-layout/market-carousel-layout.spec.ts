import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketCarouselLayout } from './market-carousel-layout';

describe('MarketCarouselLayout', () => {
  let component: MarketCarouselLayout;
  let fixture: ComponentFixture<MarketCarouselLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MarketCarouselLayout],
    }).compileComponents();

    fixture = TestBed.createComponent(MarketCarouselLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
