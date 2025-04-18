import { Routes } from '@angular/router';
import { DashboardComponent } from './features/Dashboard/dashboard/dashboard.component';
import { LoginComponent } from './features/login/login.component';
import { OtpComponent } from './features/otp/otp.component';
import { SettingsComponent } from './features/Master/settings/settings.component';
import { ChangePasswordComponent } from './features/Profile/change-password/change-password.component';
import { LefSideNavComponent } from './shared/lef-side-nav/lef-side-nav.component';
import { GmcComponent } from './features/Master/gmc/gmc.component';
import { TimesheetUpdateComponent } from './features/Hr/timesheet-update/timesheet-update.component';


export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'changePassword', component: ChangePasswordComponent },
  {path:"gmc",component:GmcComponent},
  {path:'timesheetupdate', component:TimesheetUpdateComponent},

  { path: 'otp', component: OtpComponent },
  {path:'sidebar',component:LefSideNavComponent},
  { path: '**', redirectTo: '' } 
];
