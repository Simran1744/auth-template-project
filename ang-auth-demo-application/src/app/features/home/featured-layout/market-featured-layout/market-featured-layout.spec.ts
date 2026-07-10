import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketFeaturedLayout } from './market-featured-layout';

describe('MarketFeaturedLayout', () => {
  let component: MarketFeaturedLayout;
  let fixture: ComponentFixture<MarketFeaturedLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MarketFeaturedLayout],
    }).compileComponents();

    fixture = TestBed.createComponent(MarketFeaturedLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
