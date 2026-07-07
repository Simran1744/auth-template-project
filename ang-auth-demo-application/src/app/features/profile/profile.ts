import { Component, OnInit, signal, computed, inject } from '@angular/core';
import { UserService } from '../../core/services/user-services';
import { SellerService } from '../../core/services/seller-services';
import { UserProfile } from '../../shared/models/user.model';
import { SellerProfile } from '../../shared/models/seller.model';
import { ProfileInfoCard } from './profile-info-card/profile-info-card';
import { SellerCard } from './seller-card/seller-card';

@Component({
    selector: 'app-profile',
    standalone: true,
    imports: [ProfileInfoCard, SellerCard],
    templateUrl: './profile.html',
    styleUrl: './profile.scss',
})

export class Profile implements OnInit {
    // Signal instead of plain property
    user = signal<UserProfile | null>(null);
    seller = signal<SellerProfile | null>(null);

    // Computed values derived from user signal
    isLoading = signal<boolean>(true);
    hasError = signal<boolean>(false);

    private userService = inject(UserService); // modern inject() instead of constructor
    private sellerService = inject(SellerService);

    ngOnInit(): void {
        this.userService.getProfile().subscribe({
            next: (response) => {
                this.user.set(response); // no cdr needed
                this.isLoading.set(false);
            },
            error: (err) => {
                console.error('Request failed', err);
                this.hasError.set(true);
                this.isLoading.set(false);
            }
        });
        this.sellerService.getSellerProfile().subscribe({
            next: (response) => {
                console.log('Seller profile:', response);
                this.seller.set(response);
                this.isLoading.set(false);
            },
            error: (err) => {
                console.error('Request failed', err);
            }
        });
    }

    onProfileUpdated() {
        this.userService.getProfile().subscribe({
            next: (response) => {
                this.user.set(response);
            }
        });
    }

    // parent
    onSellerApplied() {
        this.sellerService.getSellerProfile().subscribe({
            next: (response) => {
                console.log('Seller profile:', response);
                this.seller.set(response)
            }
        });
    }

}   