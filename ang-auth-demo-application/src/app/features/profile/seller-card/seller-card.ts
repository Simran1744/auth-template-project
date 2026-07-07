import { Component, inject, input, OnChanges, output, signal, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SellerProfile } from '../../../shared/models/seller.model';
import { SellerService } from '../../../core/services/seller-services';
import { SellerStatus } from '../../../shared/models/seller.model';

@Component({
  selector: 'app-seller-card',
  imports: [FormsModule],
  templateUrl: './seller-card.html',
  styleUrl: './seller-card.scss',
})

export class SellerCard implements OnChanges{

    private sellerService = inject(SellerService); // modern inject() instead of constructor
   
    // input() signal — modern replacement for @Input()
    seller = input<SellerProfile | null>(null)

    // output() signal — modern replacement for @Output()
    sellerUpdated = output<void>();

    // Local form state as signals
    displayname = signal<string>('');
    bio = signal<string>('');
    avatarUrl = signal<string>('');
    nexusModsProfileUrl = signal<string>('');
    gitHubProfileUrl = signal<string>('');
    websiteUrl = signal<string>('');
    editProfile = signal<boolean>(false);
    SellerStatus = SellerStatus; // Expose enum to template


    ngOnChanges(changes: SimpleChanges) {
        if (changes['seller'] && this.seller()) {
            this.loadFromSeller();
        }
    }

    private loadFromSeller() {
        this.displayname.set(this.seller()?.displayname ?? '');
        this.bio.set(this.seller()?.bio ?? '');
        this.avatarUrl.set(this.seller()?.avatarUrl ?? '');
        this.nexusModsProfileUrl.set(this.seller()?.nexusModsProfileUrl ?? '');
        this.gitHubProfileUrl.set(this.seller()?.gitHubProfileUrl ?? '');
        this.websiteUrl.set(this.seller()?.websiteUrl ?? '');
    }

    onEdit() {
        this.editProfile.set(true);
    }

    onCancel() {
        this.loadFromSeller();
        this.editProfile.set(false);
    }

    onApply() {
        this.sellerService.applyAsSeller(
            this.displayname(), 
            this.bio(), 
            this.avatarUrl(),
            this.nexusModsProfileUrl(),
            this.gitHubProfileUrl(),
            this.websiteUrl()
        ).subscribe({
            next: () => {
                this.editProfile.set(false);
                this.sellerUpdated.emit();
            }
        });
    }
}
