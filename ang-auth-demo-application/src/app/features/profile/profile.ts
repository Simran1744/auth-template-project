import { Component, OnInit, signal, computed, inject } from '@angular/core';
import { UserService } from '../../core/services/user-services';
import { UserProfile } from '../../shared/models/user.model';
import { ProfileInfoCard } from './profile-info-card/profile-info-card';

@Component({
    selector: 'app-profile',
    standalone: true,
    imports: [ProfileInfoCard],
    templateUrl: './profile.html',
    styleUrl: './profile.scss',
})

export class Profile implements OnInit {
    // Signal instead of plain property
    user = signal<UserProfile | null>(null);

    // Computed values derived from user signal
    isLoading = signal<boolean>(true);
    hasError = signal<boolean>(false);

    private userService = inject(UserService); // modern inject() instead of constructor

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
    }

    onProfileUpdated() {
        this.userService.getProfile().subscribe({
            next: (response) => {
                this.user.set(response);
            }
        });
    }
}