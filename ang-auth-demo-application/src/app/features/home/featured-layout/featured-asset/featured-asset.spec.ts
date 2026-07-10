import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeaturedAsset } from './featured-asset';

describe('FeaturedAsset', () => {
  let component: FeaturedAsset;
  let fixture: ComponentFixture<FeaturedAsset>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeaturedAsset],
    }).compileComponents();

    fixture = TestBed.createComponent(FeaturedAsset);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
