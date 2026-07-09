import { Component, input } from '@angular/core';
import { Asset } from '../../../../shared/models/asset.model';

@Component({
  selector: 'app-carousel-asset',
  imports: [],
  templateUrl: './carousel-asset.html',
  styleUrl: './carousel-asset.scss',
})
export class CarouselAsset {
  asset = input<Asset | null>(null);
}
