import { Component, input } from '@angular/core';
import { Asset } from '../../../../shared/models/asset.model';

@Component({
  selector: 'app-featured-asset',
  imports: [],
  templateUrl: './featured-asset.html',
  styleUrl: './featured-asset.scss',
})
export class FeaturedAsset {
  asset = input<Asset | null>(null);

}
