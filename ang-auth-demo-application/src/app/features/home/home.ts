import { Component, inject, input, OnInit, signal } from '@angular/core';
import { Asset } from '../../shared/models/asset.model';
import { AssetService } from '../../core/services/asset-services';
import { MarketBasicLayout } from "./basic-layout/market-basic-layout/market-basic-layout";
import { MarketCarouselLayout } from "./carousel-layout/market-carousel-layout/market-carousel-layout";

@Component({
  selector: 'app-home',
  imports: [MarketBasicLayout, MarketCarouselLayout],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  // Put a signal on this
  assets = signal<Asset[] | null>(null);

  // This signal will hold the most downloaded assets, which can be used in the carousel layout
  // It has 9 Items for now
  mostDownloadedAssets = signal<Asset[] | null>(null);

  private assetService = inject(AssetService);

  // Fetch all assets on component initialization
  ngOnInit(): void {
    this.assetService.getAllAssets().subscribe({
      next: (data) => {
        this.assets.set(data);
        console.log('Assets fetched successfully', data);
        this.setMostDownloadedAssets();
      },
      error: (err) => console.error('Error fetching assets', err)
    });
  }
  
  // Split assets in sub sections for display

  setMostDownloadedAssets(){
    var assets = this.assets();
    //sort by most downloaded
    if(assets){
      var sortedAssets = assets.sort((a, b) => b.totalDownloads - a.totalDownloads);
      this.mostDownloadedAssets.set(sortedAssets.slice(0, 9));
   }
   console.log('Most downloaded assets set', this.mostDownloadedAssets());
  }


}


