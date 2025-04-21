import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/header/header.component";
import { LefSideNavComponent } from "./shared/lef-side-nav/lef-side-nav.component";
import { LoginComponent } from './features/login/login.component';
import { filter } from 'rxjs/operators';
import { CommonModule } from '@angular/common';

import { Router, NavigationEnd } from '@angular/router';


@Component({

  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, LefSideNavComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'



})
export class AppComponent {
  hideLayout = false;

  constructor(private router: Router) {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        const hiddenRoutes = ['/','/login', '/otp'];
        this.hideLayout = hiddenRoutes.includes(event.urlAfterRedirects);
      });
  }
}