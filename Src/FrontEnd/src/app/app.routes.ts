import { Routes } from '@angular/router';
import { DashboardComponent } from './features/Dashboard/dashboard/dashboard.component';
import { LoginComponent } from './features/login/login.component';
import { OtpComponent } from './features/otp/otp.component';
import { SettingsComponent } from './features/Master/settings/settings.component';
import { ChangePasswordComponent } from './features/Profile/change-password/change-password.component';
import { LefSideNavComponent } from './shared/lef-side-nav/lef-side-nav.component';
import { GmcComponent } from './features/Master/gmc/gmc.component';
import { AuthGuard } from './auth.guard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  // { path: 'otp', component: OtpComponent  },
  
  
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
  { path: 'changePassword', component: ChangePasswordComponent, canActivate: [AuthGuard] },
  { path: 'gmc', component: GmcComponent, canActivate: [AuthGuard] },
  { path: 'sidebar', component: LefSideNavComponent, canActivate: [AuthGuard] },

  { path: '**', redirectTo: '' }
];
