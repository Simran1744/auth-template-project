import { Component, EventEmitter, inject, input, Input, OnChanges, OnInit, output, Output, signal, SimpleChanges } from '@angular/core';
import { UserProfile } from '../../../shared/models/user.model';
import { UserService } from '../../../core/services/user-services';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-profile-info-card',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './profile-info-card.html',
  styleUrl: './profile-info-card.scss',
})

export class ProfileInfoCard implements OnChanges {

   private userService = inject(UserService); // modern inject() instead of constructor
   
    // input() signal — modern replacement for @Input()
    user = input<UserProfile | null>(null);

    // output() signal — modern replacement for @Output()
    profileUpdated = output<void>();

    // Local form state as signals
    username = signal<string>('');
    bio = signal<string>('');
    avatarUrl = signal<string>('');
    editProfile = signal<boolean>(false);
    email = signal<string>('');

    ngOnChanges(changes: SimpleChanges) {
        if (changes['user'] && this.user()) {
            this.loadFromUser();
        }
    }

    private loadFromUser() {
        this.username.set(this.user()?.username ?? '');
        this.bio.set(this.user()?.bio ?? '');
        this.avatarUrl.set(this.user()?.avatarUrl ?? '');
        this.email.set(this.user()?.email ?? '');
    }

    onEdit() {
        this.editProfile.set(true);
    }

    onCancel() {
        this.loadFromUser();
        this.editProfile.set(false);
    }

    onSubmit() {
        this.userService.updateProfile(
            this.username(), 
            this.bio(), 
            this.avatarUrl()
        ).subscribe({
            next: () => {
                this.editProfile.set(false);
                this.profileUpdated.emit();
            }
        });
    }
}