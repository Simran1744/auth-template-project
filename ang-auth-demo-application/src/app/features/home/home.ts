import { Component, inject, input, OnInit, signal } from '@angular/core';
import { Asset } from '../../shared/models/asset.model';
import { AssetService } from '../../core/services/asset-services';
import { MarketBasicLayout } from "./basic-layout/market-basic-layout/market-basic-layout";
import { MarketCarouselLayout } from "./carousel-layout/market-carousel-layout/market-carousel-layout";
import { MarketFeaturedLayout } from "./featured-layout/market-featured-layout/market-featured-layout";

@Component({
  selector: 'app-home',
  imports: [MarketBasicLayout, MarketCarouselLayout, MarketFeaturedLayout],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  // Put a signal on this
  // This signal will hold the most downloaded assets, which can be used in the carousel layout
  // It has 9 Items for now
  mostDownloadedAssets = signal<Asset[] | null>(null);

  featuredAssets = signal<Asset[] | null>(null);

  private assetService = inject(AssetService);

  // Pagination states
  assets = signal<Asset[]>([]);
  currentPage = signal<number>(1);
  pageSize = signal<number>(12);
  totalPages = signal<number>(1);
  
  // Fetch all assets on component initialization
  ngOnInit(): void {
    this.loadAssets();
    this.loadMostDownloadedAssets();
    this.loadfeaturedAssets();
  }

  loadAssets(): void {
    this.assetService.getPagedAssets(this.currentPage(), this.pageSize()).subscribe({
      next: (response) => {
        this.assets.set(response.items);
        this.totalPages.set(response.totalPages);
        console.log('Total pages:', response.totalPages);
        console.log('Assets loaded', this.assets());
      },
      error: (err) => console.error(err)
    });
  }

  loadfeaturedAssets(){
    this.assetService.getFeaturedAssets().subscribe({
      next: (response) => {
        this.featuredAssets.set(response);
        console.log('Featured assets loaded', this.featuredAssets());
      },
      error: (err) => console.error(err)
    });
  }

  loadMostDownloadedAssets(){
    this.assetService.getMostDownloadedAssets().subscribe({
      next: (response) => {
        this.mostDownloadedAssets.set(response);
        console.log('Most downloaded assets loaded', this.mostDownloadedAssets());
      },
      error: (err) => console.error(err)
    });
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages()) {
      this.currentPage.set(page);
      console.log('Navigating to page:', page);
      this.loadAssets(); // Re-fetch data for the new page
    }
  }
  
  // Split assets in sub sections for display

  /*setMostDownloadedAssets(){
    var assets = this.assets();
    //sort by most downloaded
    if(assets){
      var sortedAssets = assets.sort((a, b) => b.totalDownloads - a.totalDownloads);
      this.mostDownloadedAssets.set(sortedAssets.slice(0, 9));
   }
   console.log('Most downloaded assets set', this.mostDownloadedAssets());
  }

  setFeaturedAssets(){
    var assets = this.assets();
    var featuredAssetsList: Asset[] = [];

    if(assets){
      for(var asset of assets){
        if(asset.isFeatured){
          featuredAssetsList.push(asset);
        }
      }
    }
    this.featuredAssets.set(featuredAssetsList);
    console.log('Featured assets set', this.featuredAssets());
  
  }*/
}

