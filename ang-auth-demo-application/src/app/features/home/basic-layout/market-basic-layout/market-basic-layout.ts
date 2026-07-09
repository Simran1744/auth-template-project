import { Component, input } from '@angular/core';
import { AssetComponent } from '../asset/asset';
import { Asset } from '../../../../shared/models/asset.model';

@Component({
  selector: 'app-market-basic-layout',
  imports: [AssetComponent],
  templateUrl: './market-basic-layout.html',
  styleUrl: './market-basic-layout.scss',
})
export class MarketBasicLayout {
  // This component serves as a basic layout for the market section of the application. 
  // Ther is no logic here, it is just a layout component that can be used to wrap other components in the market section.
  // The data has to be passed down to here from the parent home component.
  
  assets = input<Asset[] | null>(null);

}
