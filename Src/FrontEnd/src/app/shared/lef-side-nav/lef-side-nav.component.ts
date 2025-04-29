import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ProfileService, UserProfile } from '../../services/profile-services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-lef-side-nav',
  imports: [RouterLink, CommonModule],
  templateUrl: './lef-side-nav.component.html',
  styleUrl: './lef-side-nav.component.css'
})
export class LefSideNavComponent implements OnInit {
  user: UserProfile = {
    image: '',
    name: '',
    designationName: ''
  };
  imageSrc: string | null = null;



constructor(private profileService: ProfileService) {}

  ngOnInit(): void {
    const Id = 11; // Replace with dynamic ID if needed
    this.profileService.getUserProfile(Id).subscribe(profile => {
      this.user = profile;

      if (profile.image) {
        this.imageSrc = `data:image/png;base64,${profile.image}`;
        // You can also check for image type if needed
      }
    });
  }
}
