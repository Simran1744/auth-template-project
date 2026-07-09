import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarouselAsset } from './carousel-asset';

describe('CarouselAsset', () => {
  let component: CarouselAsset;
  let fixture: ComponentFixture<CarouselAsset>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarouselAsset],
    }).compileComponents();

    fixture = TestBed.createComponent(CarouselAsset);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
