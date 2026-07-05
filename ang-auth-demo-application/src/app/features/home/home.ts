import { Component, OnInit } from '@angular/core';
import { Asset } from '../../shared/models/asset.model';
import { AssetService } from '../../core/services/asset-services';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  assets: Asset[] = [];

  constructor(private assetService: AssetService) {}

  ngOnInit(): void {
    this.assetService.getAllAssets().subscribe({
      next: (data) => {
        this.assets = data;
        console.log('Assets fetched successfully', data);
      },
      error: (err) => console.error('Error fetching assets', err)
    });
  }
  

  // Here we should call the service to get all the assets and display them in the home page.

}
