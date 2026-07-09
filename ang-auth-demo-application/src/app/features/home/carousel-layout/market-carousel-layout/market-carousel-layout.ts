import { Component, input } from '@angular/core';
import { Asset } from '../../../../shared/models/asset.model';
import { CarouselAsset } from "../carousel-asset/carousel-asset";

@Component({
  selector: 'app-market-carousel-layout',
  imports: [CarouselAsset],
  templateUrl: './market-carousel-layout.html',
  styleUrl: './market-carousel-layout.scss',
})
export class MarketCarouselLayout {
  mostDownloadedAssets = input<Asset[] | null>(null);

  // Smoothly scrolls the container left or right by the pixel amount specified
  scroll(element: HTMLElement, amount: number): void {
    element.scrollBy({
      left: amount,
      behavior: 'smooth'
    });
  }
}
