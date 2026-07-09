import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketBasicLayout } from './market-basic-layout';

describe('MarketBasicLayout', () => {
  let component: MarketBasicLayout;
  let fixture: ComponentFixture<MarketBasicLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MarketBasicLayout],
    }).compileComponents();

    fixture = TestBed.createComponent(MarketBasicLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
