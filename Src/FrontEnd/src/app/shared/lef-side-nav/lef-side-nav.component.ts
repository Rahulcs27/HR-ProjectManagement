import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-lef-side-nav',
  imports: [RouterLink],
  templateUrl: './lef-side-nav.component.html',
  styleUrl: './lef-side-nav.component.css'
})
export class LefSideNavComponent {
user = {
  name: 'Vaishnavi',
  department: 'HR',
  profileImage: 'https://img.icons8.com/?size=100&id=52883&format=png&color=FFFFFF'
};

}
