import { Component, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../core/services/user-services';
import { UserProfile } from '../../shared/models/user.model';

@Component({
  selector: 'app-profile',
  imports: [FormsModule],
  templateUrl: './profile.html',
  styleUrl: './profile.scss',
})
export class Profile {
  user: UserProfile | null = null;
  username: string = '';
  bio: string | null = '';
  avatarUrl: string | null = '';
  email: string = '';
  editProfile: boolean = false;

  //Inject the UserService to call the API for updating the user profile and retrieving the user profile data
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    //Call the API to retrieve the user profile data and populate the form fields
    this.userService.getProfile().subscribe({
      next: (response) => {
        console.log('Request successful', response);
        this.user = response;
        this.username = this.user.username;
        this.bio = this.user.bio;
        this.email = this.user.email;
        this.avatarUrl = this.user.avatarUrl;
      },
      error: (err) => {
        console.error('Request failed', err);
      }
    });
  }

  onEdit(){
    this.editProfile = true;
  }

  toggleEditProfile() {
    this.editProfile = !this.editProfile;
  }

  //Call the API to update the user profile with onSubmit() method
  onSubmit() {
    console.log('Profile updated successfully');
  }

  onCancel() {
    this.editProfile = false;
  }
}
