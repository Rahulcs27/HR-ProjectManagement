import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/header/header.component";
import { LefSideNavComponent } from "./shared/lef-side-nav/lef-side-nav.component";
import { LoginComponent } from './features/login/login.component';


@Component({

  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, LefSideNavComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'



})
export class AppComponent {
  title = 'human_resource_management';
}
