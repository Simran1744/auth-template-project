import { Component, input } from '@angular/core';
import { Asset } from '../../../../shared/models/asset.model';

@Component({
  selector: 'app-asset',
  imports: [],
  templateUrl: './asset.html',
  styleUrl: './asset.scss',
})
export class AssetComponent {
  asset = input<Asset | null>(null);
}
