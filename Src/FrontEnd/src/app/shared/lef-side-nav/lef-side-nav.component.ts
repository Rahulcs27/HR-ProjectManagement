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
  const code = localStorage.getItem('userName');  // Changed empId to code

  if (code) {
    this.profileService.getUserProfile(code).subscribe(profile => {
      this.user = profile;

      if (profile.image) {
        this.imageSrc = `data:image/png;base64,${profile.image}`;
      }
    });
  } else {
    console.error('No code found. User might not be logged in.');
  
  }
}


}
