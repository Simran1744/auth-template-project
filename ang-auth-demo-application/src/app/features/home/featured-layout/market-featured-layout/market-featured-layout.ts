import { Component, input } from '@angular/core';
import { Asset } from '../../../../shared/models/asset.model';
import { FeaturedAsset } from '../featured-asset/featured-asset';

@Component({
  selector: 'app-market-featured-layout',
  imports: [FeaturedAsset],
  templateUrl: './market-featured-layout.html',
  styleUrl: './market-featured-layout.scss',
})
export class MarketFeaturedLayout {
  featuredAssets = input<Asset[] | null>(null); 

   // Smoothly scrolls the container left or right by the pixel amount specified
   scroll(element: HTMLElement, amount: number): void {
    element.scrollBy({
      left: amount,
      behavior: 'smooth'
    });
  }


}
