import { Component, inject, input, OnInit, signal } from '@angular/core';
import { Asset } from '../../shared/models/asset.model';
import { AssetService } from '../../core/services/asset-services';
import { MarketBasicLayout } from "./market-basic-layout/market-basic-layout";

@Component({
  selector: 'app-home',
  imports: [MarketBasicLayout],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  // Put a signal on this
  assets = signal<Asset[] | null>(null);

  private assetService = inject(AssetService);

  // Fetch all assets on component initialization
  ngOnInit(): void {
    this.assetService.getAllAssets().subscribe({
      next: (data) => {
        this.assets.set(data);
        console.log('Assets fetched successfully', data);
      },
      error: (err) => console.error('Error fetching assets', err)
    });
  }
  
  // Split assets in sub sections for display


}
